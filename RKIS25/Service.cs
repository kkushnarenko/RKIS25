using context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RKIS25;
public class Service
{
    private static Conetxt? _db;

    public static Conetxt GetDbContext()
    {
        if (_db == null)
        {
            _db = new Conetxt();
        }
        return _db;
    }
}
