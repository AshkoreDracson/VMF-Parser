﻿namespace VMFParser
{
    class Node
    {
        public string Name { get; private set; }
        public Node Parent { get; private set; }
        public Node RootParent
        {
            get
            {
                Node rootParent = Parent;

                while (rootParent != null && rootParent.Parent != null)
                    rootParent = rootParent.Parent;

                return rootParent;
            }
        }
        public Node RootParentOrDefault
        {
            get
            {
                return RootParent ?? this;
            }
        }

        public Node(string name, Node parent)
        {
            Name = name;
            Parent = parent;
        }

        public bool IsPartOf(string name)
        {
            Node n = this;

            while (n != null)
            {
                if (n.Name == name)
                    return true;

                n = n.Parent;
            }

            return false;
        }
    }
}