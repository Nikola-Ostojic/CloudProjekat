using Contract;
using ServiceData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityHandlerGreenWorkerRole
{
    public class PartialServerProvider : IGreen_Partial
    {
        public void DodajLiniju(int id, char[] oznaka)
        {
            TableRepositoryLinija table = new TableRepositoryLinija();

            table.AddOrReplaceLinija(new Linija(id.ToString(), oznaka));
        }
    }
}
