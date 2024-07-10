using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

public class UniversalPrinter
{
    public static void magicPrint<T>(List<T> planet)
    {
        Type type = typeof(T);
        var planetProperties = type.GetProperties();
        var headers = type.GetProperties().Where(x =>
            x.Name == "Name" ||
            x.Name == "Diameter" ||
            x.Name == "SurfaceWater" ||
            x.Name == "Population").Select(p => p.Name.ToUpper()).ToList() ;
        //var headers = planetProperties.Select(p => p.Name.ToUpper()).ToList();
        var dashes = headers.Sum(p => p.Length + (17 - p.Length));
        foreach (var headings in headers)
        {
            Console.Write($"{headings,-15} |");
        }
        Console.WriteLine();
        for (int i = 0; i < dashes; ++i)
        {
            Console.Write("-");
        }
        Console.WriteLine();
        foreach (var print in planet)
        {
            
            foreach (var prop in planetProperties)
            {
                if(headers.Contains(prop.Name.ToUpper()))
                {
                    var value = prop.GetValue(print, null);
                    Console.Write($"{value,-15} |");
                }
                else
                    continue;
                
            }
            Console.WriteLine();

        }

    }
}

