using System;

namespace PhysLib
{
	public class Quantity
    {
        private double _val;
        private double _koef;
        private Dimension _dimension;
        private Kind _kind;

        public static readonly Dimension NM = new Dimension(2, 1, -2, 0, 0, 0, 0);
        public static readonly Dimension CD = new Dimension(0, 0, 0, 0, 0, 0, 1);
        public static readonly Dimension CDnaM2 = new Dimension(-2, 0, 0, 0, 0, 0, 1);
        public static readonly Dimension naS = new Dimension(0, 0, -1, 0, 0, 0, 0);
        public static readonly Dimension JK = new Dimension(2, 1, -2, 0, -1, 0, 0);
        public static readonly Dimension NONEdim = new Dimension(0, 0, 0, 0, 0, 0, 0);

        public static readonly Dimension M = new Dimension(1, 0, 0, 0, 0, 0, 0);
        public static readonly Dimension M2 = new Dimension(2, 0, 0, 0, 0, 0, 0);
        public static readonly Dimension M3 = new Dimension(3, 0, 0, 0, 0, 0, 0);
        public static readonly Dimension M_ = new Dimension(-1, 0, 0, 0, 0, 0, 0);
        public static readonly Dimension M_2 = new Dimension(-2, 0, 0, 0, 0, 0, 0);
        public static readonly Dimension M_3 = new Dimension(-3, 0, 0, 0, 0, 0, 0);

        public static readonly Dimension Sec = new Dimension(0, 0, 1, 0, 0, 0, 0);

        public static readonly Dimension Speed = new Dimension(1, 0, -1, 0, 0, 0, 0);
        public static readonly Dimension Acceleration = new Dimension(1, 0, -2, 0, 0, 0, 0);

        public static readonly Dimension Mass = new Dimension(0, 1, 0, 0, 0, 0, 0);
        public static readonly Dimension Density = new Dimension(-3, 1, 0, 0, 0, 0, 0);
        public static readonly Dimension Molar_mass = new Dimension(0, 1, 0, 0, 0, -1, 0);
        public static readonly Dimension Impulse = new Dimension(1, 1, -1, 0, 0, 0, 0);

        public static readonly Dimension Worse = new Dimension(1, 1, -2, 0, 0, 0, 0);
        public static readonly Dimension Stiffness = new Dimension(0, 1, -2, 0, 0, 0, 0);

        public static readonly Dimension Power = new Dimension(2, 1, -3, 0, 0, 0, 0);

        public static readonly Dimension Pressure = new Dimension(-1, 1, -3, 0, 0, 0, 0);

        public static readonly Dimension Temperature = new Dimension(0, 0, 0, 0, 1, 0, 0);
        public static readonly Dimension HC_KG = new Dimension(2, 0, -2, 0, -1, 0, 0);
        public static readonly Dimension Molar_hc = new Dimension(2, 1, -2, 0, -1, -1, 0);
        public static readonly Dimension J_kg = new Dimension(2, 0, -2, 0, 0, 0, 0);

        public static readonly Dimension ElectricCurrent = new Dimension(0, 0, 0, 1, 0, 0, 0);
        public static readonly Dimension Charge = new Dimension(0, 0, 1, 1, 0, 0, 0);
        public static readonly Dimension Voltage = new Dimension(2, 1, -3, -1, 0, 0, 0);
        public static readonly Dimension Resistanse = new Dimension(2, 1, -3, -2, 0, 0, 0);
        public static readonly Dimension Conductivity = new Dimension(-2, -1, 3, 2, 0, 0, 0);
        public static readonly Dimension Resistivity = new Dimension(3, 1, -3, -2, 0, 0, 0);

        public static readonly Dimension Strength = new Dimension(1, 1, -3, -1, 0, 0, 0);
        public static readonly Dimension Capacity = new Dimension(-2, -1, 4, 2, 0, 0, 0);
        public static readonly Dimension ElectricConst = new Dimension(-3, -1, 4, 2, 0, 0, 0);
        public  static readonly Dimension KlnaM2 = new Dimension(-2, 0, 1, 1, 0, 0, 0);

        public static readonly Dimension Induction = new Dimension(0, 1, -2, -1, 0, 0, 0);
        public static readonly Dimension MagneticFlux = new Dimension(2, 1, -2, -1, 0, 0, 0);
        public static readonly Dimension Inductance = new Dimension(2, 1, -2, -2, 0, 0, 0);
        public static readonly Dimension MagneticConst = new Dimension(1, 1, -2, -2, 0, 0, 0);
        public static readonly Dimension Magnetization = new Dimension(-1, 0, 0, 1, 0, 0, 0);

        public double val
        {
            set { _val = value; }
            get { return _val; }
        }

        public double koef
        {
            set { _koef = value; }
            get { return _koef; }
        }

        public Dimension dimension
        {
            set { _dimension = value; }
            get { return _dimension; }
        }

        public Kind kind
        {
            set { _kind = value; }
            get { return _kind; } 
        }

        public Quantity(double val, double koef,
                        int l, int m, int t, int i,
                        int k, int n, int j,
                        Kind kind)
        {
            _val = val;
            _koef = koef;
            _dimension = new Dimension(l, m, t, i, k, n, j);
            _kind = kind;
        }

        public Quantity(double val, double koef,
                        int l, int m, int t, int i,
                        int k, int n, int j)
        {
            _val = val;
            _koef = koef;
            _dimension = new Dimension(l, m, t, i, k, n, j);
            _kind = Kind.None_kind;
        }

        public Quantity(double val,
                        int l, int m, int t, int i,
                        int k, int n, int j,
                        Kind kind)
        {
            _val = val;
            _koef = 1;
            _dimension = new Dimension(l, m, t, i, k, n, j);
            _kind = kind;
        }

        public Quantity(double val,
                        int l, int m, int t, int i,
                        int k, int n, int j)
        {
            _val = val;
            _koef = 1;
            _dimension = new Dimension(l, m, t, i, k, n, j);
            _kind = Kind.None_kind;
        }

        public Quantity(double val, double koef,
                        Kind kind)
        {
            _val = val;
            _koef = koef;
            _dimension = new Dimension(0, 0, 0, 0, 0, 0, 0);
            _kind = kind;
        }

        public Quantity(double val, double koef)
        {
            _val = val;
            _koef = koef;
            _dimension = new Dimension(0, 0, 0, 0, 0, 0, 0);
            _kind = Kind.None_kind;
        }

        public Quantity(double val,
                        Kind kind)
        {
            _val = val;
            _koef = 1;
            _dimension = new Dimension(0, 0, 0, 0, 0, 0, 0);
            _kind = kind;
        }

        public Quantity(double val)
        {
            _val = val;
            _koef = 1;
            _dimension = new Dimension(0, 0, 0, 0, 0, 0, 0);
            _kind = Kind.None_kind;
        }

        public Quantity(double val, double koef,
                        Dimension di,
                        Kind kind)
        {
            _val = val;
            _koef = koef;
            _dimension = di; 
            _kind = kind;
        }

        public Quantity(double val, double koef,
                        Dimension di)
        {
            _val = val;
            _koef = koef;
            _dimension = di; 
            _kind = Kind.None_kind;
        }

        public Quantity(double val,
                        Dimension di,
                        Kind kind)
        {
            _val = val;
            _koef = 1;
            _dimension = di;
            _kind = kind;
        } 

        public Quantity(double val,
                        Dimension di)
        {
            _val = val;
            _koef = 1;
            _dimension = di;
            _kind = Kind.None_kind;
        }

        public static Quantity operator +(Quantity a, Quantity b)
        {
            if (a.dimension == b.dimension)
            {
                if (a.kind == b.kind)
                {
                    return new Quantity((a.val * a.koef + b.val * b.koef) / System.Math.Min(a.koef, b.koef), System.Math.Min(a.koef, b.koef), a.dimension, a.kind);
                }
                else if (a.kind == Kind.Unknown)
                {
                    return new Quantity((a.val * a.koef + b.val * b.koef) / System.Math.Min(a.koef, b.koef), System.Math.Min(a.koef, b.koef), a.dimension, a.kind);
                }
                else if (b.kind == Kind.Unknown)
                {
                    return new Quantity((a.val * a.koef + b.val * b.koef) / System.Math.Min(a.koef, b.koef), System.Math.Min(a.koef, b.koef), a.dimension, b.kind);
                }
                else
                {
                    throw new ArgumentException("It is not possible to add quantities of different kind!");
                }
            }
            else
            {
                throw new ArgumentException("It is not possible to add quantities of different dimensions!");
            }
        }

        public static Quantity operator -(Quantity a, Quantity b)
        {
            if (a.dimension == b.dimension)
            {
                if (a.kind == b.kind)
                {
                    return new Quantity((a.val * a.koef - b.val * b.koef) / System.Math.Min(a.koef, b.koef), System.Math.Min(a.koef, b.koef), a.dimension, a.kind);
                }
                else if (a.kind == Kind.Unknown)
                {
                    return new Quantity((a.val * a.koef - b.val * b.koef) / System.Math.Min(a.koef, b.koef), System.Math.Min(a.koef, b.koef), a.dimension, a.kind);
                }
                else if (b.kind == Kind.Unknown)
                {
                    return new Quantity((a.val * a.koef - b.val * b.koef) / System.Math.Min(a.koef, b.koef), System.Math.Min(a.koef, b.koef), a.dimension, b.kind);
                }
                else
                {
                    throw new ArgumentException("It is not possible to sub quantities of different kind!");
                }
            }
            else
            {
                throw new ArgumentException("It is not possible to sub quantities of different dimensions!");
            }
        }

        public static Quantity operator *(Quantity a, Quantity b)
        {
            Quantity tmp;
            if (a.dimension == NONEdim)
            {
                tmp = new Quantity(a.val * b.val * a.koef, b.koef, a.dimension + b.dimension);
				tmp.kind=b.kind;
            }
            else if (b.dimension == NONEdim)
            { 
                tmp = new Quantity(a.val * b.val * b.koef, a.koef, a.dimension + b.dimension);
				tmp.kind=a.kind;
			}
            else
            {
                tmp = new Quantity(a.val * b.val, a.koef * b.koef, a.dimension + b.dimension);
            }
            if (tmp.dimension == JK || tmp.dimension == NM || tmp.dimension == naS || tmp.dimension == CDnaM2 || tmp.dimension == NONEdim)
            {
                tmp.kind = Kind.Unknown;
            }
            else if (tmp.dimension == CD)
            {
                if (a.kind == Kind.Srad || b.kind == Kind.Srad)
                {
                    tmp.kind = Kind.Lm;
                }
                else
                {
                    tmp.kind = Kind.Unknown;
                }
            }
            return tmp; 
        }

        public static Quantity operator /(Quantity a, Quantity b)
        {
            Quantity tmp;
            if (a.dimension == NONEdim)
            {
                tmp = new Quantity(a.val / b.val * a.koef, 1 / b.koef, a.dimension - b.dimension); 
            }
            else if (b.dimension == NONEdim)
            { 
                tmp = new Quantity(a.val / b.val / b.koef, a.koef, a.dimension - b.dimension); 
            }
            else
            {
                tmp = new Quantity(a.val / b.val, a.koef / b.koef, a.dimension - b.dimension); 
            }
            if (tmp.dimension == JK || tmp.dimension == NM || tmp.dimension == NONEdim)
            {
                tmp.kind = Kind.Unknown;
            }
            else if (tmp.dimension == CDnaM2)
            {
                if (a.kind == Kind.Cd_m2)
                { 
                    tmp.kind = Kind.Cd_m2;
                }
                else if (a.kind == Kind.Lm)
                {
                    tmp.kind = Kind.Lx;
                }
                else
                {
                    tmp.kind = Kind.Unknown;
                }
            }
            else if (tmp.dimension == CD)
            {
                if (a.kind == Kind.Lm && b.kind == Kind.Rad)
                {
                    tmp.kind = Kind.Cd;
                }
                else
                {
                    tmp.kind = Kind.Unknown;
                }
            }
            return tmp; 
        }

        public override string ToString()
        {
            string tmp = _val.ToString();
            Dimension KG = new Dimension(0, 1, 0, 0, 0, 0, 0);
            if (_dimension == KG)
            {
                switch (_koef)
                {
                    case 1000.0:
                        tmp += " tn";
                        break;
                    case 1.0:
                        tmp += " kg";
                        break;
                    case 0.001:
                        tmp += " g";
                        break;
                    default:
                        tmp += " * 10^" + System.Math.Log10(_koef).ToString();
                        break;
                }
            }
            else if (_dimension == NONEdim)
            {
                switch (_koef)
                {
                    case System.Math.PI:
                        tmp += "π";
                        break;
                    case System.Math.PI / 180:
                        tmp += "°";
                        break;
                    case System.Math.PI / (180 * 60):
                        tmp += "′";
                        break;
                    case System.Math.PI / (180 * 60 * 60):
                        tmp += "″";
                        break;
                    case 0.01:
						tmp +="%";
						break; 
                    default:
                        tmp += " * 10^" + System.Math.Log10(_koef);
                        break;
                }
            } else if(_dimension==Sec) 
            {
				switch(_koef) {
					case 3600:
						tmp+="h";
						break;
					case 60:
						tmp+="min";
						break;
					case 1E+0: tmp += " s"; break;
                    case 1E-1: tmp += " ds"; break;
                    case 1E-2: tmp += " cs"; break;
                    case 1E-3: tmp += " ms"; break;
                    case 1E-6: tmp += " μs"; break;
                    case 1E-9: tmp += " ns"; break;
                    case 1E-12: tmp += " ps"; break;
                    case 1E-15: tmp += " fs"; break;
                    case 1E-18: tmp += " as"; break;
                    case 1E-21: tmp += " zs"; break;
                    case 1E-24: tmp += " ys"; break;
                    default:
                        tmp += "*" + _koef.ToString();
                        break;
				}
			}
			else if(_dimension==Speed)
			{
				double kMetr=1, kSec=1;
				if(Phys.GetMantissaExact(_koef)==Phys.GetMantissaExact(1.0/60)) 
				{
					kMetr=_koef*60;
					kSec=60;
				} else if(Phys.GetMantissaExact(_koef)==Phys.GetMantissaExact(1.0/3600))
				{
					kMetr=_koef*3600;
					kSec=3600;
				} else
				{
					kMetr=_koef;
				}
				switch (kMetr)
                {
                    case 1E+24: tmp += " Y"; break;
                    case 1E+21: tmp += " Z"; break;
                    case 1E+18: tmp += " E"; break;
                    case 1E+15: tmp += " P"; break;
                    case 1E+12: tmp += " T"; break;
                    case 1E+9: tmp += " G"; break;
                    case 1E+6: tmp += " M"; break;
                    case 1E+3: tmp += " k"; break;
                    case 1E+2: tmp += " h"; break;
                    case 1E+1: tmp += " da"; break;
                    case 1E+0: break;
                    case 1E-1: tmp += " d"; break;
                    case 1E-2: tmp += " c"; break;
                    case 1E-3: tmp += " m"; break;
                    case 1E-6: tmp += " μ"; break;
                    case 1E-9: tmp += " n"; break;
                    case 1E-12: tmp += " p"; break;
                    case 1E-15: tmp += " f"; break;
                    case 1E-18: tmp += " a"; break;
                    case 1E-21: tmp += " z"; break;
                    case 1E-24: tmp += " y"; break;
                    default:
                        tmp += "*" + kMetr.ToString();
                        break;
                }
                tmp+="m/";
                switch(kSec) {
					case 3600:
						tmp+="h";
						break;
					case 60:
						tmp+="min";
						break;
					case 1E+0: tmp += "s"; break;
				}
			}
            else
            {
                double coefficient;
                if (_dimension == M2 || _dimension == M_2)
                {
                    coefficient = System.Math.Pow(_koef, 0.5);
                }
                else if (_dimension == M3 || _dimension == M_3)
                {
                    coefficient = System.Math.Pow(_koef, 1.0 / 3.0);
                }
                else
                {
                    coefficient = _koef;
                }
                switch (coefficient)
                {
                    case 1E+24: tmp += " Y"; break;
                    case 1E+21: tmp += " Z"; break;
                    case 1E+18: tmp += " E"; break;
                    case 1E+15: tmp += " P"; break;
                    case 1E+12: tmp += " T"; break;
                    case 1E+9: tmp += " G"; break;
                    case 1E+6: tmp += " M"; break;
                    case 1E+3: tmp += " k"; break;
                    case 1E+2: tmp += " h"; break;
                    case 1E+1: tmp += " da"; break;
                    case 1E+0: break;
                    case 1E-1: tmp += " d"; break;
                    case 1E-2: tmp += " c"; break;
                    case 1E-3: tmp += " m"; break;
                    case 1E-6: tmp += " μ"; break;
                    case 1E-9: tmp += " n"; break;
                    case 1E-12: tmp += " p"; break;
                    case 1E-15: tmp += " f"; break;
                    case 1E-18: tmp += " a"; break;
                    case 1E-21: tmp += " z"; break;
                    case 1E-24: tmp += " y"; break;
                    default:
                        tmp += "*" + coefficient.ToString();
                        break;
                }
                
                if (_dimension == NM)
                {
                    if (_kind == Kind.N_m) tmp += "N*m";
                    else if (_kind == Kind.Work) tmp += "J";
                    else tmp += "m^2*kg/s^-2";
                }
                else if (_dimension == CD)
                {
                    if (_kind == Kind.Lm) tmp += "lm";
                    else tmp += "cd";
                }
                else if (_dimension == CDnaM2)
                {
                    if (_kind == Kind.Lx) tmp += "lx";
                    else tmp += "cd";
                }
                else if (_dimension == naS)
                {
                    if (_kind == Kind.Gz) tmp += "Hz";
                    else if (_kind == Kind.Bq) tmp += "Bq";
                    else if (_kind == Kind.Rad_S) tmp += "rad/s";
                    else tmp += "s^-1";
                }
                else if (_dimension == JK)
                {
                    tmp += "J/K";
                }
                else if (_dimension == NONEdim)
                {
                    if (_kind == Kind.Rad) tmp += "rad";
                    else if (_kind == Kind.Srad) tmp += "srad";
                }
                else if (_dimension == Worse)
                {
                    tmp += "N";
                }
                else if (_dimension == Stiffness)
                {
                    tmp += "N/m";
                }
                else if (_dimension == Power)
                {
                    tmp += "W";
                }
                else if (_dimension == Pressure)
                {
                    tmp += "Pa";
                }
                else if (_dimension == HC_KG)
                {
                    tmp += "J/kg*K";
                }
                else if (_dimension == Molar_hc)
                {
                    tmp += "J/K*mol";
                }
                else if (_dimension == J_kg)
                {
                    tmp += "J/kg";
                }
                else if (_dimension == Charge)
                {
                    tmp += "q";
                }
                else if (_dimension == Voltage)
                {
                    tmp += "V";
                }
                else if (_dimension == Resistanse)
                {
                    tmp += "Ω";
                }
                else if (_dimension == Conductivity)
                {
                    tmp += "S";
                }
                else if (_dimension == Resistivity)
                {
                    tmp += "Ω*m";
                }
                else if (_dimension == Strength)
                {
                    tmp += "V/m";
                }
                else if (_dimension == Capacity)
                {
                    tmp += "F";
                }
                else if (_dimension == ElectricConst)
                {
                    tmp += "F/m";
                }
                else if (_dimension == KlnaM2)
                {
                    tmp += "q/m^2";
                }
                else if (_dimension == Induction)
                {
                    tmp += "T";
                }
                else if (_dimension == MagneticFlux)
                {
                    tmp += "Wb";
                }
                else if (_dimension == Inductance)
                {
                    tmp += "H";
                }
                else if (_dimension == MagneticConst)
                {
                    tmp += "H/m";
                }
                else
                {
                    bool nominator = false, denominator = false;
                    if (_dimension.L > 0)
                    {
                        tmp += "m";
                        if (_dimension.L > 1) tmp += "^" + _dimension.L.ToString();
                        nominator = true;
                    }
                    if (_dimension.M > 0)
                    {
                        if (nominator) tmp += "*";
                        tmp += "kg";
                        if (_dimension.M > 1) tmp += "^" + _dimension.M.ToString();
                        nominator = true;
                    }
                    if (_dimension.T > 0)
                    {
                        if (nominator) tmp += "*";
                        tmp += "s";
                        if (_dimension.T > 1) tmp += "^" + _dimension.T.ToString();
                        nominator = true;
                    }
                    if (_dimension.I > 0)
                    {
                        if (nominator) tmp += "*";
                        tmp += "A";
                        if (_dimension.I > 1) tmp += "^" + _dimension.I.ToString();
                        nominator = true;
                    }
                    if (_dimension.K > 0)
                    {
                        if (nominator) tmp += "*";
                        tmp += "K";
                        if (_dimension.K > 1) tmp += "^" + _dimension.K.ToString();
                        nominator = true;
                    }
                    if (_dimension.N > 0)
                    {
                        if (nominator) tmp += "*";
                        tmp += "mol";
                        if (_dimension.N > 1) tmp += "^" + _dimension.N.ToString(); 
                        nominator = true;
                    }
                    if (_dimension.J > 0)
                    {
                        if (nominator) tmp += "*";
                        tmp += "cd";
                        if (_dimension.J > 1) tmp += "^" + _dimension.J.ToString(); 
                        nominator = true;
                    }
                    if (_dimension.L < 0)
                    {
                        if (nominator)
                        {
                            tmp += "/m";
                            if (_dimension.L < -1) tmp += "^" + (-1 * _dimension.L).ToString();
                        }
                        else tmp += "m^" + _dimension.L.ToString();
                        denominator = true; 
                    }
                    if (_dimension.M < 0)
                    {
                        if (denominator)
                        {
                            if (nominator)
                            {
                                tmp += "*kg";
                                if (_dimension.M < -1) tmp += "^" + (-1 * _dimension.M).ToString();
                            }
                            else tmp += "^" + _dimension.M.ToString(); 
                        }
                        else
                        {
                            if (nominator)
                            {
                                tmp += "/kg";
                                if (_dimension.M < -1) tmp += "^" + (-1 * _dimension.M).ToString();
                            }
                            else tmp += "kg^" + _dimension.M.ToString();
                        }
                        denominator = true; 
                    }
                    if (_dimension.T < 0)
                    {
                        if (denominator)
                        {
                            if (nominator)
                            {
                                tmp += "*s";
                                if (_dimension.T < -1) tmp += "^" + (-1 * _dimension.T).ToString();
                            }
                            else tmp += "^" + _dimension.T.ToString(); 
                        }
                        else
                        {
                            if (nominator)
                            {
                                tmp += "/s";
                                if (_dimension.T < -1) tmp += "^" + (-1 * _dimension.T).ToString();
                            }
                            else tmp += "s^" + _dimension.T.ToString();
                        }
                        denominator = true; 
                    }
                    if (_dimension.I < 0)
                    {
                        if (denominator)
                        {
                            if (nominator)
                            {
                                tmp += "*A";
                                if (_dimension.I < -1) tmp += "^" + (-1 * _dimension.I).ToString();
                            }
                            else tmp += "^" + _dimension.I.ToString(); 
                        }
                        else
                        {
                            if (nominator)
                            {
                                tmp += "/A";
                                if (_dimension.I < -1) tmp += "^" + (-1 * _dimension.I).ToString();
                            }
                            else tmp += "A^" + _dimension.I.ToString();
                        }
                        denominator = true; 
                    }
                    if (_dimension.K < 0)
                    {
                        if (denominator)
                        {
                            if (nominator)
                            {
                                tmp += "*K";
                                if (_dimension.K < -1) tmp += "^" + (-1 * _dimension.K).ToString();
                            }
                            else tmp += "^" + _dimension.K.ToString(); 
                        }
                        else
                        {
                            if (nominator)
                            {
                                tmp += "/K";
                                if (_dimension.K < -1) tmp += "^" + (-1 * _dimension.K).ToString();
                            }
                            else tmp += "K^" + _dimension.K.ToString();
                        }
                        denominator = true; 
                    }
                    if (_dimension.N < 0)
                    {
                        if (denominator)
                        {
                            if (nominator)
                            {
                                tmp += "*mol";
                                if (_dimension.N < -1) tmp += "^" + (-1 * _dimension.N).ToString();
                            }
                            else tmp += "^" + _dimension.N.ToString(); 
                        }
                        else
                        {
                            if (nominator)
                            {
                                tmp += "/mol";
                                if (_dimension.N < -1) tmp += "^" + (-1 * _dimension.N).ToString();
                            }
                            else tmp += "mol^" + _dimension.N.ToString();
                        }
                        denominator = true; 
                    }
                    if (_dimension.J < 0)
                    {
                        if (denominator)
                        {
                            if (nominator)
                            {
                                tmp += "*cd";
                                if (_dimension.J < -1) tmp += "^" + (-1 * _dimension.J).ToString();
                            }
                            else tmp += "^" + _dimension.J.ToString(); 
                        }
                        else
                        {
                            if (nominator)
                            {
                                tmp += "/cd";
                                if (_dimension.J < -1) tmp += "^" + (-1 * _dimension.J).ToString();
                            }
                            else tmp += "cd^" + _dimension.J.ToString();
                        }
                        denominator = true; 
                    }
                }
                return tmp;
            }
            return tmp; 
        }
    }
}
