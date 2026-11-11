using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Globalization;

namespace PhysLib
{
    public static class Phys
    {
        // Словарь единиц. Ссылаемся на статические поля Quantity, чтобы размерность
        // в точности совпадала с той, которую ожидает ToString().
        private static readonly Dictionary<string, (double coef, Dimension dimen, Kind ki)> unit = 
            new Dictionary<string, (double, Dimension, Kind)>
        {
            // Электричество и магнетизм
            {"A/m", (1, Quantity.Magnetization, Kind.None_kind)},
            {"H/m", (1, Quantity.MagneticConst, Kind.None_kind)},
            {"H", (1, Quantity.Inductance, Kind.None_kind)},
            {"Wb", (1, Quantity.MagneticFlux, Kind.None_kind)},
            {"T", (1, Quantity.Induction, Kind.None_kind)},
            {"q/m^2", (1, Quantity.KlnaM2, Kind.None_kind)},
            {"F/m", (1, Quantity.ElectricConst, Kind.None_kind)},
            {"F", (1, Quantity.Capacity, Kind.None_kind)},
            {"V/m", (1, Quantity.Strength, Kind.None_kind)},
            {"Ω*m", (1, Quantity.Resistivity, Kind.None_kind)},
            {"S", (1, Quantity.Conductivity, Kind.None_kind)},
            {"Ω", (1, Quantity.Resistanse, Kind.None_kind)},
            {"V", (1, Quantity.Voltage, Kind.None_kind)},
            {"q", (1, Quantity.Charge, Kind.None_kind)},
            {"A", (1, Quantity.ElectricCurrent, Kind.None_kind)},
            
            // Термодинамика
            {"J/kg", (1, Quantity.J_kg, Kind.None_kind)},
            {"J/K*mol", (1, Quantity.Molar_hc, Kind.None_kind)},
            {"J/kg*K", (1, Quantity.HC_KG, Kind.None_kind)},
            {"J/K", (1, Quantity.JK, Kind.Unknown)},
            {"K", (1, Quantity.Temperature, Kind.None_kind)},
            
            // Механика
            {"Pa", (1, Quantity.Pressure, Kind.None_kind)},
            {"W", (1, Quantity.Power, Kind.None_kind)},
            {"N/m", (1, Quantity.Stiffness, Kind.None_kind)},
            {"N*m", (1, Quantity.NM, Kind.N_m)},
            {"J", (1, Quantity.NM, Kind.Work)},
            {"N", (1, Quantity.Worse, Kind.None_kind)},
            {"m*kg/s", (1, Quantity.Impulse, Kind.None_kind)},
            {"kg/mol", (1, Quantity.Molar_mass, Kind.None_kind)},
            {"g/mol", (0.001, Quantity.Molar_mass, Kind.None_kind)},
            
            // Количество вещества и масса
            {"mol", (1, new Dimension(0,0,0,0,0,1,0), Kind.None_kind)},
            {"kg", (1, Quantity.Mass, Kind.None_kind)},
            {"tn", (1000, Quantity.Mass, Kind.None_kind)},
            {"g", (0.001, Quantity.Mass, Kind.None_kind)},
            
            // Время
            {"h", (3600, Quantity.Sec, Kind.None_kind)},
            {"min", (60, Quantity.Sec, Kind.None_kind)},
            {"s", (1, Quantity.Sec, Kind.None_kind)},
            
            // Свет и радиоактивность
            {"Gz", (1, Quantity.naS, Kind.Gz)},
            {"Bq", (1, Quantity.naS, Kind.Bq)},
            {"cd/m^2", (1, Quantity.CDnaM2, Kind.Cd_m2)},
            {"lx", (1, Quantity.CDnaM2, Kind.Lx)},
            {"lm", (1, Quantity.CD, Kind.Lm)},
            {"cd", (1, Quantity.CD, Kind.Cd)},
            {"rad/s", (1, Quantity.naS, Kind.Rad_S)},
            
            // Геометрия и углы
            {"m^3", (1, Quantity.M3, Kind.None_kind)},
            {"m^2", (1, Quantity.M2, Kind.None_kind)},
            {"m", (1, Quantity.M, Kind.None_kind)},
            {"rad", (1, Quantity.NONEdim, Kind.Rad)},
            {"srad", (1, Quantity.NONEdim, Kind.Srad)},
            {"°", (Math.PI / 180, Quantity.NONEdim, Kind.Rad)},
            {"′", (Math.PI / 180 / 60, Quantity.NONEdim, Kind.Rad)},
            {"″", (Math.PI / 180 / 3600, Quantity.NONEdim, Kind.Rad)}
        };

        public static double GetMantissaExact(double n)
        {
            if (n == 0) return 0;
            string s = System.Math.Abs(n).ToString("E15", CultureInfo.InvariantCulture);
            string mantissaStr = s.Substring(0, s.IndexOf('E'));
            return double.Parse(mantissaStr, CultureInfo.InvariantCulture);
        }
        
        public static Quantity Sqrt(Quantity a)
        {
			if(a.dimension.L%2==0 && a.dimension.M%2==0 && a.dimension.T%2==0 && a.dimension.I%2==0 && a.dimension.K%2==0 && a.dimension.N%2==0 && a.dimension.J%2==0)
			{
				if(a.koef==Math.PI) 
				{
					a.val*=a.koef;
					a.koef=0;
				}
				return new Quantity(Math.Sqrt(a.val), Math.Sqrt(a.koef), a.dimension.L/2, a.dimension.M/2, a.dimension.T/2, a.dimension.I/2, a.dimension.K/2, a.dimension.N/2, a.dimension.J/2); 
			} else
			{
				throw new ArgumentException("NE chetnye stepeny razmernostey");
			}
        }
        
        public static Quantity Procent(Quantity a, Quantity b)
        {
			if (a.dimension == b.dimension)
            {
                if (a.kind == b.kind)
                {
                    return new Quantity(a.val*a.koef/(b.val*b.koef)*100, 0.01, Quantity.NONEdim, Kind.None_kind);
                }
                else if (a.kind == Kind.Unknown)
                {
                    return new Quantity(a.val*a.koef/(b.val*b.koef)*100, 0.01, Quantity.NONEdim, Kind.None_kind);
                }
                else if (b.kind == Kind.Unknown)
                {
                    return new Quantity(a.val*a.koef/(b.val*b.koef)*100, 0.01, Quantity.NONEdim, Kind.None_kind);
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

        private static double GetPrefixMultiplier(string str, out string remaining)
        {
            remaining = str;
            if (string.IsNullOrEmpty(str)) return 1.0;

            // Двухбуквенные приставки
            if (str.StartsWith("da") && str.Length > 2)
            {
                remaining = str.Substring(2);
                return 1e1;
            }

            if (str.Length > 1)
            {
                char c = str[0];
                double mult = 1.0;
                switch (c)
                {
                    case 'Y': mult = 1e24; break;
                    case 'Z': mult = 1e21; break;
                    case 'E': mult = 1e18; break;
                    case 'P': if (str[1] != 'a') mult = 1e15; break; // Pa
                    case 'T': if (char.IsLetter(str[1])) mult = 1e12; break; // T (Tesla)
                    case 'G': if (str[1] != 'z') mult = 1e9; break; // Gz
                    case 'M': mult = 1e6; break;
                    case 'k': if (str[1] != 'g') mult = 1e3; break; // kg
                    case 'h': if (char.IsLetter(str[1])) mult = 1e2; break; // h (hour)
                    case 'd': mult = 1e-1; break;
                    case 'c': mult = 1e-2; break;
                    case 'm': if (char.IsLetter(str[1])) mult = 1e-3; break; // m (meter)
                    case 'μ': case 'u': mult = 1e-6; break;
                    case 'n': mult = 1e-9; break;
                    case 'p': mult = 1e-12; break;
                    case 'f': mult = 1e-15; break;
                    case 'a': mult = 1e-18; break;
                    case 'z': mult = 1e-21; break;
                    case 'y': mult = 1e-24; break;
                }

                if (mult != 1.0)
                {
                    remaining = str.Substring(1);
                    return mult;
                }
            }

            return 1.0;
        }

        public static Quantity QuantityParse(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) throw new ArgumentException("Empty string");

            str = str.Replace(" ", "");
            double val = 0.0;
            double coeff = 1.0;

            // 1. Число
            Match match = Regex.Match(str, @"^\d+(\.\d+)?");
            if (match.Success)
            {
                val = double.Parse(match.Value, CultureInfo.InvariantCulture);
                str = str.Remove(0, match.Length);
            }
            else if (str.StartsWith("π"))
            {
                val = Math.PI;
                str = str.Remove(0, 1);
            }
            else
            {
                throw new ArgumentException("Parse error: number expected");
            }

            // 2. π в коэффициенте
            if (str.StartsWith("π"))
            {
                coeff *= Math.PI;
                str = str.Remove(0, 1);
                if (str.StartsWith("/"))
                {
                    str = str.Remove(0, 1);
                    match = Regex.Match(str, @"^\d+");
                    if (match.Success)
                    {
                        val /= double.Parse(match.Value);
                        str = str.Remove(0, match.Length);
                    }
                }
            }

            Quantity tmp = new Quantity(val, coeff);
            bool denominator = false;

            // 3. Цикл парсинга единиц
            while (str.Length > 0)
            {
                bool found = false;
                var sortedUnits = new List<string>(unit.Keys);
                sortedUnits.Sort((a, b) => b.Length.CompareTo(a.Length));

                // Сначала ищем точное совпадение (km, m^2, h и т.д.)
                foreach (var key in sortedUnits)
                {
                    if (str.StartsWith(key))
                    {
                        str = str.Remove(0, key.Length);
                        var info = unit[key];
                        
                        int pow = 1;
                        if (str.StartsWith("^"))
                        {
                            str = str.Remove(0, 1);
                            match = Regex.Match(str, @"^-?\d+");
                            if (match.Success)
                            {
                                pow = int.Parse(match.Value);
                                str = str.Remove(0, match.Length);
                            }
                            else throw new ArgumentException("Parse error: power expected");
                        }

                        Dimension finalDim = info.dimen * pow;
                        
                        if (denominator)
                            tmp = tmp / new Quantity(1, info.coef, finalDim, info.ki);
                        else
                            tmp = tmp * new Quantity(1, info.coef, finalDim, info.ki);
                        
                        found = true;
                        break;
                    }
                }

                // Если не нашли, пробуем приставку
                if (!found)
                {
                    string tempStr = str;
                    double prefixMult = GetPrefixMultiplier(tempStr, out string remainingStr);
                    
                    if (prefixMult != 1.0)
                    {
                        foreach (var key in sortedUnits)
                        {
                            if (remainingStr.StartsWith(key))
                            {
                                str = remainingStr.Remove(0, key.Length);
                                var info = unit[key];
                                
                                int pow = 1;
                                if (str.StartsWith("^"))
                                {
                                    str = str.Remove(0, 1);
                                    match = Regex.Match(str, @"^-?\d+");
                                    if (match.Success)
                                    {
                                        pow = int.Parse(match.Value);
                                        str = str.Remove(0, match.Length);
                                    }
                                }

                                Dimension finalDim = info.dimen * pow;
                                double finalCoef = info.coef * prefixMult;

                                if (denominator)
                                    tmp = tmp / new Quantity(1, finalCoef, finalDim, info.ki);
                                else
                                    tmp = tmp * new Quantity(1, finalCoef, finalDim, info.ki);
                                
                                found = true;
                                break;
                            }
                        }
                    }
                }

                if (!found) throw new ArgumentException($"Unknown unit: {str}");

                // 4. Оператор * или /
                if (str.Length > 0)
                {
                    switch (str[0])
                    {
                        case '*':
                            str = str.Remove(0, 1);
                            break;
                        case '/':
                            str = str.Remove(0, 1);
                            denominator = true;
                            break;
                        default:
                            throw new ArgumentException($"Expected * or /, found: {str[0]}");
                    }
                }
            }

            return tmp;
        }
    }
}
