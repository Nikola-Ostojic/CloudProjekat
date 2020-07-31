using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    [ServiceContract]
    public interface IBlue1
    {
        [OperationContract]
        void DodajAutobus(int id, string ime);

        [OperationContract]
        void DodajVozaca(int id, string oznaka_ime, char[] oznaka, string prezime);

    }
}
