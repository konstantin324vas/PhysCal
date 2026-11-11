using System;
using PhysLib;

namespace MyConsoleApp
{    
    class Program    
    {        
        static void Main(string[] args)        
        {            
            while(true)
            {
                Quantity a = null;
                Quantity b = null;
                Quantity c = null;

                // --- Ввод первой величины ---
                Console.WriteLine("Input first quantity:");
                while (true)
                {
                    try
                    {
                        a = Phys.QuantityParse(Console.ReadLine());
                        break; // Успешно распарсили - выходим из цикла
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}. Попробуйте снова:");
                    }
                }

                // --- Ввод оператора ---
                string oper;
                while(true)
                {
                    Console.WriteLine("Input operator (+,-,*,/,√,%):");
                    oper = Console.ReadLine()?.Trim(); 
                    if(oper[0] == '+' || oper[0] == '-' || oper[0] == '*' || oper[0] == '/' || oper[0] == '√' || oper[0] == '%')
                    {
                        break;
                    } 
                    else 
                    {
                        Console.WriteLine("Invalid operator. Try again.");
                    }
                }

                // --- Ввод второй величины (если нужно) ---
                if(oper != "√")
                {
                    Console.WriteLine("Input second quantity:");
                    while(true)
                    {
                        try 
                        {
                            b = Phys.QuantityParse(Console.ReadLine());
                            break; // Успешно распарсили
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ошибка: {ex.Message}. Попробуйте снова:");
                        }
                    }
                } 

                // --- Вычисление ---
                try
                {
                    switch(oper[0])
                    {
                        case '+':
                            c = a + b;
                            break;
                        case '-':
                            c = a - b;
                            break;
                        case '*':
                            c = a * b;
                            break;
                        case '/':
                            c = a / b;
                            break;
                        case '√':
                            // Предполагается, что метод Phys.Sqrt возвращает Quantity
                            c = Phys.Sqrt(a); 
                            break;
                        case '%':
                            // Предполагается, что метод Phys.Procent возвращает Quantity
                            c = Phys.Procent(a, b);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка вычисления: {ex.Message}");
                    continue; // Возвращаемся в начало цикла
                }

                // --- Вывод результата ---
                Console.WriteLine($"Result: {c}"); // Вызов ToString() произойдет автоматически

                // --- Выход? ---
                string answer;
                while(true)
                {
                    Console.WriteLine("Exit? (y/n)");
                    answer = Console.ReadLine();
                    if(answer == "y" || answer == "n")
                    {
                        break;
                    }
                    Console.WriteLine("Please enter 'y' or 'n'.");
                }
                if(answer == "y")
                {
                    break;
                }
            } 
        }    
    }
}
