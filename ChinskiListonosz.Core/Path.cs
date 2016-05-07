using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinskiListonosz.Core
{
    public class Path
    {
        public LinkedList<Edge> Edges = new LinkedList<Edge>();
        private int start;
        public int Start
        {
            get { return start; }
            private set { start = value; }
        }

        private int end;
        public int End
        {
            get { return end; }
            private set { end = value; }
        }

        public Path(Edge e, bool reverse = false)
        {
            Edges.AddLast(e);
            if (reverse)
            {
                Start = e.U;
                End = e.V;
            }
            else
            {
                Start = e.V;
                End = e.U;
            }
        }
        public Path(Path p)
        {
            Start = p.Start;
            End = p.End;
            Edges = new LinkedList<Edge>(p.Edges.Select(e => e.Clone()));
        }
        public Path(int startVertex)
        {
            this.Start = startVertex;
            this.End = startVertex;
        }
        public Path(IEnumerable<Edge> edges, int start) : this(start)
        {
            foreach (var e in edges)
                this.AddToEnd(e);
        }
        public Path(IEnumerable<Edge> edges) : this(edges, edges.First().U) { }
        public Path Clone()
        {
            return new Path(this);
        }

        public int Length
        {
            get
            {
                return Edges.Sum(e => e.W);
            }
        }

        public Path AddToEnd(Edge e)
        {
            if (End == e.U)
            {
                Edges.AddLast(e);
                End = e.V;
            }
            else if (End == e.V)
            {
                Edges.AddLast(e);
                End = e.U;
            }
            else
                throw new ArgumentException("The edge is not connecting to the end of the Path");
            return this;
        }
        public Path AddToStart(Edge e)
        {
            if (Start == e.U)
            {
                Edges.AddFirst(e);
                Start = e.V;
            }
            else if (Start == e.V)
            {
                Edges.AddFirst(e);
                Start = e.U;
            }
            else
                throw new ArgumentException("The edge is not connecting to the start of the Path");
            return this;
        }

        public bool Connects(int u, int v)
        {
            return (Start == u && End == v) || (Start == v && End == u);
        }


    }
}
