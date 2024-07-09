using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

//public class UniversalPrinter
//{
//    public static void printTable(IReadOnlyList<object> planets) //need to pass in myDeserializedData
//    {
//        if (planets.Count == 0) return;
//        Type type = planets[0].GetType();
//        var headers = type.GetProperties().Where(x => x.Name == "name" ||
//        x.Name == "diameter" ||
//        x.Name == "surface_water" ||
//        x.Name == "population");

//        foreach (var item in headers)
//        {
//            Console.Write(item.Name, " ");
//        }
//    }
//}

public static class UniversalPrinter
{
    public static void printTable(Root planets) //need to pass in myDeserializedData
    {
        if (planets.count == 0) return;
        Type resultType = typeof(Result);
        //Type type = planets.GetType();
        var headers = resultType.GetProperties();
        foreach(var header in headers)
        {
            Console.WriteLine($"{header.Name} ");
        }

        foreach (var result in planets.results)
        {
            foreach (var header in headers)
            {
                var value = header.GetValue(headers);
                Console.WriteLine($"{value} ");
            }

        }
    }
}

//void magicPrint(Planets planet)
//{
//    Type type = planet.GetType();
//    var planetProperties = type.GetProperties();
//    foreach (var item in planetProperties)
//    {
//        Console.Write($"{(item.Name).ToUpper()} ");
//    }
//}

//List<Object> planets