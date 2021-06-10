using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AIS_AsepKomarudin_Test.Models
{
    public class DB_Product
    {
        private SqlConnection con;
        private void Connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["SQLConn"].ToString();
            con = new SqlConnection(constring);
        }

        public List<Product> GetProducts()
        {
            Connection();
            List<Product> getAllProduct = new List<Product>();

            SqlCommand cmd = new SqlCommand("SP_RetriveCountingProducts", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                getAllProduct.Add(
                    new Product
                    {   Id=Convert.ToInt32(dr["Id"]),
                        Barcode = Convert.ToInt32(dr["Barcode"]),
                        Product_Name = Convert.ToString(dr["Product_Name"]),
                        Price = Convert.ToDecimal(dr["Price"]),
                        Status = Convert.ToString(dr["status"]),
                       
                    });
            }
            return getAllProduct;
        }

        public List<ReportProduct> RetriveReportProducts()
        {
            Connection();
            List<ReportProduct> reportproducts = new List<ReportProduct>();

            SqlCommand cmd = new SqlCommand("SP_RetriveCountingProducts", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                reportproducts.Add(
                    new ReportProduct
                    {
                        Barcode = Convert.ToInt32(dr["barcode"]),
                        Jumlah = Convert.ToInt32(dr["jumlah"]),
                        Total_harga = Convert.ToDecimal(dr["total_harga"]),
                        ready = Convert.ToInt32(dr["ready"]),
                        onhold = Convert.ToInt32(dr["onhold"]),
                        delivered = Convert.ToInt32(dr["delivered"]),
                        packing = Convert.ToInt32(dr["packing"]),
                        sent = Convert.ToInt32(dr["sent"]),
                    });
            }
            return reportproducts;
        }

    }
}