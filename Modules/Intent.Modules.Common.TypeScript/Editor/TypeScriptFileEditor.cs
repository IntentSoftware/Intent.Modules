using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using Intent.Modules.Common.TypeScript.Editor.Parsing;
using Zu.TypeScript;
using Zu.TypeScript.Change;
using Zu.TypeScript.TsTypes;

namespace Intent.Modules.Common.TypeScript.Editor
{
    public class TypeScriptFile : TypeScriptNode
    {
        public TypeScriptFile(Node node, TypeScriptFileEditor editor) : base(node, editor)
        {
        }

        public override string GetIdentifier(Node node)
        {
            return null;
        }

        public override void AddChild(TypeScriptNode node)
        {
            if (Imports.Count > 0)
            {
                InsertAfter(Imports.Last(), node);
                return;
            }
            base.AddChild(node);
        }

        public IList<TypeScriptFileImport> Imports { get; } = new List<TypeScriptFileImport>();
        public IList<TypeScriptClass> Classes => Children.Where(x => x is TypeScriptClass).Cast<TypeScriptClass>().ToList();
        public IList<TypeScriptInterface> Interfaces => Children.Where(x => x is TypeScriptInterface).Cast<TypeScriptInterface>().ToList();

        public void AddImport(TypeScriptFileImport import)
        {
            if (Imports.Any())
            {
                var existingLocation = Imports.FirstOrDefault(x => x.Location == import.Location);
                if (existingLocation != null)
                {
                    foreach (var importType in import.Types)
                    {
                        if (!existingLocation.HasType(importType))
                        {
                            existingLocation.AddType(importType);
                        }
                    }
                }
                else
                {
                    Editor.InsertAfter(Imports.Last(), import.GetTextWithComments());
                }
            }
            else
            {
                Editor.InsertBefore(this, import.GetTextWithComments());
            }
        }

        public void AddImportIfNotExists(string className, string location)
        {
            if (Imports.Any())
            {
                if (Imports.All(x => x.Location != location && x.Types.All(t => t != className)))
                {
                    Editor.InsertAfter(Imports.Last(), $@"
import {{ {className} }} from '{location}';");
                }
            }
            else
            {
                Editor.InsertBefore(this, $@"
import {{ {className} }} from '{location}';");
            }
        }

        public string GetSource()
        {
            return Editor.GetSource();
        }
    }

    public class TypeScriptFileEditor
    {
        private string _source;
        public TypeScriptAST Ast;

        public ChangeAST Change;

        private IList<TypeScriptNode> _registeredNodes = new List<TypeScriptNode>();

        public TypeScriptFileEditor(string source)
        {
            _source = source;
            Ast = new TypeScriptAST(_source);
            Change = new ChangeAST();
            File = new TypeScriptFile(Ast.RootNode, this);
            var listener = new TypeScriptFileTreeWalker(File, this);
            listener.WalkTree();
        }

        public TypeScriptFile File { get; }

        public void InsertAfter(TypeScriptNode node, string text)
        {
            InsertAfter(node.Node, text);
        }

        public void InsertAfter(Node node, string text)
        {
            Change.InsertAfter(node, text);
            UpdateNodes();
        }

        public void InsertBefore(TypeScriptNode node, string text)
        {
           InsertBefore(node.Node, text);
        }

        public void InsertBefore(Node node, string text)
        {
            Change.InsertBefore(node, text);
            UpdateNodes();
        }

        public void Insert(int index, TypeScriptNode node)
        {
            Insert(index, node.GetTextWithComments());
        }

        public void Insert(int index, string text)
        {
            _source = _source.Insert(index, text);
            UpdateNodes();
        }

        public void ReplaceNode(Node node, string replaceWith = "")
        {
            if (node.GetTextWithComments() == replaceWith)
            {
                return;
            }
            _source = _source
                .Remove(node.Pos.Value, node.End.Value - node.Pos.Value)
                .Insert(node.Pos.Value, replaceWith);
            UpdateNodes();
        }

        public void Replace(TypeScriptNode node, string text)
        {
            ReplaceNode(node.Node, text);
        }

        public void UpdateNodes()
        {
            _source = Change.GetChangedSource(_source);
            Ast = new TypeScriptAST(_source);
            Change = new ChangeAST();
            File.UpdateNode(Ast.RootNode);
            var walker = new TypeScriptFileTreeWalker(File, this);
            walker.WalkTree();
        }

        //private List<TypeScriptFileImport> _imports;
        //public List<TypeScriptFileImport> Imports()
        //{
        //    return _imports ?? (_imports = Ast.OfKind(SyntaxKind.ImportDeclaration).Select(x => new TypeScriptFileImport(x, this)).ToList());
        //}

        //public bool ImportExists(TypeScriptFileImport import)
        //{
        //    return import.Types.All(type => Imports().Exists(x => x.HasType(type) && x.Location == import.Location));
        //}



        //public IList<TypeScriptVariableStatement> VariableDeclarations()
        //{
        //    return Ast.RootNode.Children.Where(x => x.Kind == SyntaxKind.VariableStatement).Select(x => new TypeScriptVariableStatement(x, this)).ToList();
        //}

        //public IList<TypeScriptExpressionStatement> ExpressionStatements()
        //{
        //    return Ast.RootNode.Children.Where(x => x.Kind == SyntaxKind.ExpressionStatement).Select(x => new TypeScriptExpressionStatement(x, this)).ToList();
        //}

        //public IList<TypeScriptClass> ClassDeclarations()
        //{
        //    return Ast.RootNode.Children.Where(x => x.Kind == SyntaxKind.ClassDeclaration).Select(x => new TypeScriptClass(x, this)).ToList();
        //}

        //public IList<TypeScriptClass> InterfaceDeclarations()
        //{
        //    return Ast.RootNode.Children.Where(x => x.Kind == SyntaxKind.InterfaceDeclaration).Select(x => new TypeScriptClass(x, this)).ToList();
        //}

        //public void AddVariableDeclaration(string declaration)
        //{
        //    var variables = Ast.RootNode.Children.Where(x => x.Kind == SyntaxKind.VariableStatement);
        //    Change.InsertAfter(variables.Any() ? variables.Last() : Ast.RootNode.Children.Last(), declaration);
        //    UpdateChanges();
        //}

        //public void AddExpressionStatement(string declaration)
        //{
        //    var existings = Ast.RootNode.Children.Where(x => x.Kind == SyntaxKind.ExpressionStatement);
        //    Change.InsertAfter(existings.Any() ? existings.Last() : Ast.RootNode.Children.Last(), declaration);
        //    UpdateChanges();
        //}

        //public void AddClass(string declaration)
        //{
        //    var classes = Ast.RootNode.Children.Where(x => x.Kind == SyntaxKind.ClassDeclaration);
        //    Change.InsertAfter(classes.Any() ? classes.Last() : Ast.RootNode.Children.Last(), declaration);
        //    UpdateChanges();
        //}

        //public void AddInterface(string declaration)
        //{
        //    var interfaces = Ast.RootNode.Children.Where(x => x.Kind == SyntaxKind.InterfaceDeclaration);
        //    Change.InsertAfter(interfaces.Any() ? interfaces.Last() : Ast.RootNode.Children.Last(), declaration);
        //    UpdateChanges();
        //}



        public string GetSource()
        {
            return _source;
        }

        //public void UpdateChanges()
        //{
        //    _source = Change.GetChangedSource(_source);
        //    Ast = new TypeScriptAST(_source);
        //    Change = new ChangeAST();
        //    //foreach (var node in _registeredNodes)
        //    //{
        //    //    node.UpdateNode();
        //    //}
        //}

        public void Register(TypeScriptNode node)
        {
            _registeredNodes.Add(node);
        }

        public void Unregister(TypeScriptNode node)
        {
            _registeredNodes.Remove(node);
        }
        
        public override string ToString()
        {
            return _source;
        }
    }
}