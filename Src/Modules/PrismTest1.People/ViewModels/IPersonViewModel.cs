using PrismTest1.Business;
using PrismTest1.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismTest1.People.ViewModels
{
    public interface IPersonViewModel: IViewModel
    {
        Person Person { get; set; }
    }
}
