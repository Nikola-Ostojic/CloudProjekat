using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    [ServiceContract]
    public interface IBlue1_Partial
    {

            [OperationContract]
            void DodajVozaca(int id, string ime, char[] oznaka, string prezime);

            [OperationContract]
            void DodajAutobus(int id, string ime);
    }
}
