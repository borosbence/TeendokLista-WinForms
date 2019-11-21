using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeendokLista.ViewInterfaces
{
    interface ILoginView
    {
        string ErrorMessage { get; set; }
        string UserName { get; }
        string Password { get; }
    }
}
