using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UniversalPrinter
{
    public static void printTable(IReadOnlyList<object> planets)
    {
        if(planets.Count == 0) return;
        Type type = planets[0].GetType();
        var headers = type.GetProperties().Where(x => x.Name == "name" || 
        x.Name == "diameter" ||
        x.Name == "surface_water" ||
        x.Name == "population");

        foreach( var item in headers )
        {
            Console.Write(item.Name, " ");
        }



    }
}

//List<Object> planets