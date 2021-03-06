﻿namespace Vermeille
{
    public class Exo5
    {
        private HashTable h;

        public Exo5()
        {
            h = new HashTable();
            h.Initialize();
        }

        public void Insert(int e)
        {
            h.Insert(e);
        }

        public bool Mem(int e)
        {
            return h.Search(e);
        }

        public void Delete(int e)
        {
            h.Delete(e);
        }
    }

    internal class HashTable
    {
        private const int NbEntries = 997;
        private LinkedList[] _entries;

        public void Initialize()
        {
            _entries = new LinkedList[NbEntries];
        }

        public void Insert(int e)
        {
            int aux = e % NbEntries;
            if (_entries[aux] == null)
                _entries[aux] = new LinkedList();
            _entries[aux].Insert(e);
        }

        public void Delete(int e)
        {
            _entries[e%NbEntries].Delete(e);
        }

        public bool Search(int e)
        {
            return _entries[e%NbEntries].Search(e);
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < NbEntries; i++)
                if (_entries[i] != null)
                    s += i + " : " + _entries[i] + "\n";
            return s;
        }
    }

    internal class LinkedList
    {
        private class Node
        {
            public int Value;
            public Node Next;
        }

        private Node _head;

        public LinkedList()
        {
            _head = null;
            Count = 0;
        }

        public int Count { get; private set; }

        public void Insert(int e)
        {
            Node prev = null;
            Node curr = _head;
            while (curr != null && curr.Value < e)
            {
                prev = curr;
                curr = curr.Next;
            }
            if (curr != null && curr.Value == e)
                return;
            Node n = new Node {Value = e};
            if (prev == null)
            {
                n.Next = _head;
                _head = n;
            }
            else
            {
                prev.Next = n;
                n.Next = curr;
            }
            ++Count;
        }

        public void Delete(int e)
        {
            if (_head == null)
                return;
            Node prev = null;
            Node curr = _head;
            while (curr != null && curr.Value != e)
            {
                prev = curr;
                curr = curr.Next;
            }
            if (prev == null)
                _head = curr.Next;
            else
                if (curr != null) prev.Next = curr.Next;
            --Count;
        }

        public override string ToString()
        {
            string s = "";
            Node p = _head;
            while (p != null)
            {
                s += p.Value + " -> ";
                p = p.Next;
            }
            s += Count;
            return s;
        }

        public bool Search(int e)
        {
            Node p = _head;
            while (p != null)
            {
                if (p.Value == e)
                    return true;
                if (p.Value > e)
                    return false;
                p = p.Next;
            }
            return false;
        }
    }
}
