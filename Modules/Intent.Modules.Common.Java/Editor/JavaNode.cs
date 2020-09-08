﻿using System;
using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Intent.Modules.Common.Java.Editor.Parser;
using JavaParserLib;

namespace Intent.Modules.Common.Java.Editor
{
    public abstract class JavaNode : IEquatable<JavaNode>
    {
        private readonly List<JavaNode> _children = new List<JavaNode>();

        protected JavaNode(ParserRuleContext context, JavaFile file)
        {
            File = file;
            UpdateContext(context);
        }

        protected JavaNode(ParserRuleContext context, JavaNode parent) : this(context, parent.File)
        {
            Parent = parent;
        }

        public JavaFile File { get; protected set; }
        public string Identifier => GetIdentifier(Context);
        protected abstract string GetIdentifier(ParserRuleContext context);
        public ParserRuleContext Context { get; private set; }
        public JavaNode Parent { get; }
        public IList<JavaNode> Children => _children;
        public IList<JavaAnnotation> Annotations { get; } = new List<JavaAnnotation>();
        public IToken StartToken => File.GetCommentsAndWhitespaceBefore(Context.Start).StartToken ?? Context.Start;
        public IToken StopToken => Context.Stop;

        public JavaNode TryGetChild(ParserRuleContext context)
        {
            return Children.SingleOrDefault(x => x.Context.GetType() == context.GetType() &&  x.Identifier == x.GetIdentifier(context));
        }

        public void InsertBefore(JavaNode existing, JavaNode node)
        {
            if (HasChild(node))
            {
                throw new InvalidOperationException("Child already exists: " + node.ToString());
            }
            //Children.Insert(Children.IndexOf(existing), node);
            File.InsertBefore(existing, node.GetText());
        }

        public void InsertAfter(JavaNode existing, JavaNode node)
        {
            if (HasChild(node))
            {
                throw new InvalidOperationException("Child already exists: " + node.ToString());
            }
            //Children.Insert(Children.IndexOf(existing) + 1, node);
            File.InsertAfter(existing, node.GetText());
        }

        public bool HasChild(JavaNode node)
        {
            return Children.Contains(node);
        }

        public void InsertChild(int index, JavaNode node)
        {
            _children.Insert(index, node);
        }

        public JavaAnnotation TryGetAnnotation(Java9Parser.AnnotationContext context)
        {
            return Annotations.SingleOrDefault(x => x.Context.GetType() == context.GetType() &&  x.Identifier == x.GetIdentifier(context));
        }

        public void InsertAnnotation(int index, JavaAnnotation annotation)
        {
            Annotations.Insert(index, annotation);
        }

        public virtual string GetText()
        {
            var ws = File.GetCommentsAndWhitespaceBefore(Context.Start);
            return $"{ws.Text}{Context.GetFullText()}";
            //return Context.GetFullText();
        }

        public void ReplaceWith(string text)
        {
            File.Replace(this, text);
        }

        public void Remove()
        {
            File.Replace(this, "");
        }

        public virtual bool IsIgnored()
        {
            return Annotations.Any(x => x.Identifier.StartsWith("@IntentIgnore"));// || Node.GetTextWithComments().TrimStart().StartsWith("//@IntentIgnore()");
        }

        public virtual bool IsMerged()
        {
            return Annotations.Any(x => x.Identifier.StartsWith("@IntentMerge"));// || Node.GetTextWithComments().TrimStart().StartsWith("//@IntentMerge()");
        }

        public void UpdateContext(RuleContext fromContext)
        {
            Context = (ParserRuleContext) fromContext;
        }

        public bool Equals(JavaNode other)
        {
            return Identifier == other?.Identifier;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((JavaNode)obj);
        }

        public override int GetHashCode()
        {
            return Identifier.GetHashCode();
        }


        public override string ToString()
        {
            return GetText();
        }
    }
}