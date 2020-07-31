using Contract;
using ServiceData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityHandlerBlueWorkerRole
{
    public class PartialServerProvider : IBlue1_Partial
    {
        public void DodajAutobus(int id, string oznaka)
        {
            TableRepositoryAutobus table = new TableRepositoryAutobus();

            table.AddOrReplaceAutobus(new Autobus(id.ToString(), oznaka));
        }

        public void DodajVozaca(int id, string ime, char[] oznaka, string prezime)
        {
            TableRepositoryVozac table = new TableRepositoryVozac();

            table.AddOrReplaceVozac(new ServiceData.Vozac(id.ToString(), ime, oznaka, prezime));
        }
    }
}
