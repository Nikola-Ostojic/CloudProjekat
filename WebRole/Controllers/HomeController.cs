using Contract;
using ServiceData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebRole.Controllers
{
    public class HomeController : Controller
    {
        public static int id = 0;

        public ActionResult Index()
        {
            string uniqueBlobName = string.Format("poruka_{0}_{1}", DateTime.Now.ToShortDateString(), ++id);

            BlobHelper blobHelper = new BlobHelper();
            string text = blobHelper.DownloadFromBlob(uniqueBlobName);

            if (text == null)
            {
                id--;
                return RedirectToAction("Autobus");
            }
            else if (text.Equals("Blue"))
            {
                return RedirectToAction("Autobus");
            }
            else
            {
                return RedirectToAction("Vozac");
            }
        }

        public ActionResult Autobus()
        {
            return View("Autobus");
        }

        public ActionResult DodajAutobus(int id, string oznaka)
        {
            Task.Factory.StartNew(() =>
            {

                NetTcpBinding binding = new NetTcpBinding();

                EndpointAddress address1 = new EndpointAddress("net.tcp://localhost:8951/InputRequest_Blue");

                ChannelFactory<IBlue1> channelFactory = new ChannelFactory<IBlue1>(binding, address1);

                IBlue1 proxy = channelFactory.CreateChannel();

                proxy.DodajAutobus(Convert.ToInt32(id), oznaka);

            });


            return RedirectToAction("Vozac");
        }


        public ActionResult Vozac()
        {
            return View();
        }

        public ActionResult DodajVozaca(int ID, string Ime, string Oznaka, string Prezime)
        {
            Task.Factory.StartNew(() =>
            {

                NetTcpBinding binding = new NetTcpBinding();

                EndpointAddress address1 = new EndpointAddress("net.tcp://localhost:8951/InputRequest_Blue");

                ChannelFactory<IBlue1> channelFactory = new ChannelFactory<IBlue1>(binding, address1);

                IBlue1 proxy = channelFactory.CreateChannel();

                proxy.DodajVozaca(Convert.ToInt32(ID), Ime, Oznaka.ToCharArray(), Prezime);

            });


            return RedirectToAction("Index");
        }


        public ActionResult Linija()
        {
            return View();
        }

        public ActionResult DodajLiniju(int ID, string Oznaka)
        {
            Task.Factory.StartNew(() =>
            {

                NetTcpBinding binding = new NetTcpBinding();

                EndpointAddress address1 = new EndpointAddress("net.tcp://localhost:8951/InputRequest_Green");

                ChannelFactory<IGreen> channelFactory = new ChannelFactory<IGreen>(binding, address1);

                IGreen proxy = channelFactory.CreateChannel();

                proxy.DodajLiniju(Convert.ToInt32(ID), Oznaka.ToCharArray());

            });


            return RedirectToAction("Index");
        }
    }
}