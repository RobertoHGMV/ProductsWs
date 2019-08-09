using ProdctsWs.Domain.Services;
using ProductsWs.Business.Services;
using ProductsWs.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace ProductsWs.WS.WebServices
{
    /// <summary>
    /// Descrição resumida de ProductWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que esse serviço da web seja chamado a partir do script, usando ASP.NET AJAX, remova os comentários da linha a seguir. 
    // [System.Web.Script.Services.ScriptService]
    public class ProductWS : System.Web.Services.WebService
    {
        IProductService _service;

        public ProductWS()
        {
            _service = new ProductService();
        }

        [WebMethod]
        public ProductModel Get(string itemCode)
        {
            try
            {
                return _service.Get(itemCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public List<ProductModel> GetAll()
        {
            try
            {
                return _service.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public void Add(ProductModel model)
        {
            try
            {
                _service.Add(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public void Update(ProductModel model)
        {
            try
            {
                _service.Update(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public void Delete(string itemCode)
        {
            try
            {
                _service.Delete(itemCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
