using System;

namespace PhysLib
{
	public class Dimension
    {
        private int _L; //m
        private int _M; //kg
        private int _T; //s
        private int _I; //A
        private int _K; //K
        private int _N; //nu
        private int _J; //cd

        public Dimension(int l, int m, int t, int i, int k, int n, int j)
        {
            _L = l;
            _M = m;
            _T = t;
            _I = i;
            _K = k;
            _N = n;
            _J = j;
        }
        public Dimension()
        {
			_L = 0;
            _M = 0;
            _T = 0;
            _I = 0;
            _K = 0;
            _N = 0;
            _J = 0;
		}

        public int L { set { _L = value; } get { return _L; } }
        public int M { set { _M = value; } get { return _M; } }
        public int T { set { _T = value; } get { return _T; } }
        public int I { set { _I = value; } get { return _I; } }
        public int K { set { _K = value; } get { return _K; } }
        public int N { set { _N = value; } get { return _N; } }
        public int J { set { _J = value; } get { return _J; } }

        public static Dimension operator +(Dimension a, Dimension b)
        {
            return new Dimension(a.L + b.L, a.M + b.M, a.T + b.T, a.I + b.I, a.K + b.K, a.N + b.N, a.J + b.J);
        }

        public static Dimension operator -(Dimension a, Dimension b)
        {
            return new Dimension(a.L - b.L, a.M - b.M, a.T - b.T, a.I - b.I, a.K - b.K, a.N - b.N, a.J - b.J);
        }
        
        public static Dimension operator *(Dimension a, int b)
        {
			return new Dimension(a.L*b, a.M*b, a.T*b, a.I*b, a.K*b, a.N*b, a.J*b); 
		}
		
		public static Dimension operator *(int a, Dimension b)
        {
			return new Dimension(b.L*a, b.M*a, b.T*a, b.I*a, b.K*a, b.N*a, b.J*a ); 
		}

        public static bool operator ==(Dimension a, Dimension b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;
            return a.L == b.L && a.M == b.M && a.T == b.T && a.I == b.I && a.K == b.K && a.N == b.N && a.J == b.J;
        }

        public static bool operator !=(Dimension a, Dimension b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            return obj is Dimension d && this == d;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_L, _M, _T, _I, _K, _N, _J);
        }
    }

}
