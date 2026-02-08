using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Task
{
    public string Baslik;
    public bool Tamamlandi;

    public Task(string baslik)
    {
        Baslik = baslik;
        Tamamlandi = false;
    }
}
