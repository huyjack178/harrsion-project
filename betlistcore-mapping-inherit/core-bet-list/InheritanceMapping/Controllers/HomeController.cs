using InheritanceMapping.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Caching;
using System.Text;
using System.Web.Compilation;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InheritanceMapping.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            MappingModel model = new MappingModel();
            return View(model);
        }

        public void ExportExcelFullData()
        {
            DataTable fullDt = GetBetTypesOfProductsData();
            AddBaseTypeToDataTable(ref fullDt);
            ExportToExcel(fullDt);
        }

        public void ExportExcelProductData(MappingModel model)
        {
            DataTable fullDt = GetBetTypesOfProductsData();
            AddBaseTypeToDataTable(ref fullDt);
            DataTable productDt = GetProductData(model.ProductId, fullDt);
            ExportToExcel(productDt);
        }

        public void ExportExcelMappingData(MappingModel model)
        {
            DataTable fullDt = GetBetTypesOfProductsData();
            AddBaseTypeToDataTable(ref fullDt);
            DataTable deviredDt = GetDeviredTypesOfBetTypeWithProductId(model.ProductId, fullDt, model.BaseType);
            ExportToExcel(deviredDt);
        }

        private DataTable GetProductData(string productId, DataTable dt)
        {
            DataTable productDt = dt.AsEnumerable().Where(row => row["ProductID"].ToString() == productId).CopyToDataTable();
            productDt.Columns.Remove("ChoiceBaseType");
            productDt.Columns.Remove("StatusBaseType");
            productDt.Columns.Remove("OddsBaseType");
            productDt.Columns.Remove("StakeBaseType");
            productDt.Columns.Remove("TransBaseType");
            return productDt;
        }

        private DataTable GetDeviredTypesOfBetTypeWithProductId(string productId, DataTable dt, string baseType)
        {
            DataTable resultDt = new DataTable();

            GetDeviredTypesRecursive(dt, ref resultDt, productId, 0, baseType);
            return resultDt;
        }

        private void GetDeviredTypesRecursive(DataTable dt, ref DataTable resultDt, string productId, int baseIndex, string baseType)
        {
            string baseTypeCol = baseType + "BaseType";
            if (baseIndex == 0)
            {
                DataTable productDt = GetProductData(productId, dt);
                resultDt.Columns.Add("BetType" + baseIndex);
                foreach (DataRow productRow in productDt.Rows)
                {
                    string betTypeId = productRow["BetType"].ToString();
                    DataRow newRow = resultDt.NewRow();
                    newRow["BetType" + baseIndex] = betTypeId;
                    var deviredTypes = dt.AsEnumerable().Where(tempRow => tempRow[baseTypeCol].ToString() == betTypeId && tempRow["ProductID"].ToString() != productId).ToList();
                    if(deviredTypes.Count != 0)
                    {
                        resultDt.Rows.Add(newRow);
                        GetDeviredTypesRecursive(dt, ref resultDt, productId, baseIndex + 1, baseType);
                    }
                }
            }
            else
            {
                int rowId = resultDt.Rows.Count - 1;
                string newBetTypeId = resultDt.Rows[rowId]["BetType" + (baseIndex - 1)].ToString();
                var deviredTypes = dt.AsEnumerable().Where(tempRow => tempRow[baseTypeCol].ToString() == newBetTypeId && tempRow["ProductID"].ToString() != productId).ToList();
                if (deviredTypes.Count != 0)
                {
                    if (!resultDt.Columns.Contains("ProductId" + baseIndex))
                    {
                        resultDt.Columns.Add("ProductId" + baseIndex);
                        resultDt.Columns.Add("ProductName" + baseIndex);
                        resultDt.Columns.Add("BetType" + (baseIndex));
                    }
                    foreach (DataRow deviredType in deviredTypes)
                    {
                        DataRow newRow = resultDt.NewRow();

                        newRow["ProductId" + baseIndex] = deviredType["ProductID"];
                        newRow["ProductName" + baseIndex] = deviredType["ProductName"];
                        newRow["BetType" + (baseIndex)] = deviredType["BetType"];
                        resultDt.Rows.Add(newRow);
                        GetDeviredTypesRecursive(dt, ref resultDt, deviredType["ProductID"].ToString(), baseIndex + 1, baseType);
                    }
                }
            }
        }

        public void AddBaseTypeToDataTable(ref DataTable fullDt)
        {
            try
            {
                fullDt.Columns.Add("ChoiceBaseType");
                fullDt.Columns.Add("StatusBaseType");
                fullDt.Columns.Add("OddsBaseType");
                fullDt.Columns.Add("StakeBaseType");
                fullDt.Columns.Add("TransBaseType");
                string baseNamespaceBuilder = "Fanex.BetList.Core.Builder";

                for (int rowId = 0; rowId < fullDt.Rows.Count; rowId++)
                {
                    //Choice
                    string namespaceBuilder = ".ChoiceBuilder";
                    string typeName = string.Empty;

                    DataRow row = fullDt.Rows[rowId];
                    typeName = baseNamespaceBuilder + namespaceBuilder + ".Choice" + row["BetType"].ToString();
                    Type t = GetBetListAssemblies(typeName);
                    if (t != null)
                    {
                        Type baseType = t.BaseType;
                        fullDt.Rows[rowId]["ChoiceBaseType"] = baseType.Name.Replace("Choice", string.Empty);
                    }

                    namespaceBuilder = ".StatusBuilder";
                    typeName = baseNamespaceBuilder + namespaceBuilder + ".Status" + row["BetType"].ToString();
                    t = GetBetListAssemblies(typeName);
                    if (t != null)
                    {
                        Type baseType = t.BaseType;
                        fullDt.Rows[rowId]["StatusBaseType"] = baseType.Name.Replace("Status", string.Empty);
                    }

                    namespaceBuilder = ".StakeBuilder";
                    typeName = baseNamespaceBuilder + namespaceBuilder + ".Stake" + row["BetType"].ToString();
                    t = GetBetListAssemblies(typeName);
                    if (t != null)
                    {
                        Type baseType = t.BaseType;
                        fullDt.Rows[rowId]["StakeBaseType"] = baseType.Name.Replace("Stake", string.Empty);
                    }

                    namespaceBuilder = ".OddsBuilder";
                    typeName = baseNamespaceBuilder + namespaceBuilder + ".Odds" + row["BetType"].ToString();
                    t = GetBetListAssemblies(typeName);
                    if (t != null)
                    {
                        Type baseType = t.BaseType;
                        fullDt.Rows[rowId]["OddsBaseType"] = baseType.Name.Replace("Odds", string.Empty);
                    }

                    namespaceBuilder = ".TransBuilder";
                    typeName = baseNamespaceBuilder + namespaceBuilder + ".Trans" + row["BetType"].ToString();
                    t = GetBetListAssemblies(typeName);
                    if (t != null)
                    {
                        Type baseType = t.BaseType;
                        fullDt.Rows[rowId]["TransBaseType"] = baseType.Name.Replace("Trans", string.Empty);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private DataTable GetBetTypesOfProductsData()
        {
            string connectionString = "Data Source=10.18.200.215;Initial Catalog=bodb02;Persist Security Info=True;User ID=accteam;Password=@dragon#";
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(GetSelectBetTypesOfProductsQuery(), conn);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                return dt;
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }

        private string GetSelectBetTypesOfProductsQuery()
        {
            StringBuilder query = new StringBuilder(1000);
            query.Append(" SELECT DISTINCT A.ProductID");
            query.Append(" ,D.ProductName");
            query.Append(" ,A.BetType");
            query.Append(" ,C.typenamee");
            query.Append(" FROM SportBettypeMatrix AS A WITH (NOLOCK)");
            query.Append(" ,Sports AS B WITH (NOLOCK)");
            query.Append(" ,bettype AS C WITH (NOLOCK)");
            query.Append(" ,Products AS D WITH (NOLOCK)");
            query.Append(" WHERE A.ProductID = D.ProductID");
            query.Append(" AND A.SportType = B.SportType");
            query.Append(" AND A.BetType = C.typeid");
            query.Append(" ORDER BY A.ProductID");

            return query.ToString();
        }

        private Type GetBetListAssemblies(string typeName)
        {
            ObjectCache cache = MemoryCache.Default;

            var assemblies = (List<Assembly>)cache["Fanex.BetList.Core.CacheKey"];

            if (assemblies == null || !assemblies.Any())
            {
                try

                {
                    assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToList();
                }
                catch
                {
                    assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
                }

                CacheItemPolicy policy = new CacheItemPolicy();
                policy.Priority = CacheItemPriority.NotRemovable;

                assemblies = assemblies.Where(x => x.FullName.StartsWith("Fanex.", StringComparison.InvariantCulture)).ToList();

                cache.Set("Fanex.BetList.Core.CacheKey", assemblies, policy);
            }

            foreach (var assembly in assemblies)
            {
                Type type = Type.GetType(typeName + ", " + assembly);

                if (type != null)
                {
                    return type;
                }
            }

            return null;
        }

        protected void ExportToExcel(DataTable dt)
        {
            //Get the data from database into datatable

            //Create a dummy GridView
            GridView GridView1 = new GridView();
            GridView1.AllowPaging = false;
            GridView1.DataSource = dt;
            GridView1.DataBind();

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
             "attachment;filename=DataTable.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                //Apply text style to each Row
                GridView1.Rows[i].Attributes.Add("class", "textmode");
            }
            GridView1.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}