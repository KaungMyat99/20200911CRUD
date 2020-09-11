using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using _20200911CRUD.Models;
using static  _20200911CRUD.Common.CommonMethod;
using static _20200911CRUD.ProcedureConstant;
using System.Data;

namespace _20200911CRUD.DataAccess
{
    public class SQLDataAccess
    {
        private SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "20200831CRUDwithAjax",
            UserID = "sa",
            Password = "sasa"
        };

      public ProductModel SelectProduct()
        {
            ProductModel model = null;
            try
            {
                SqlConnection con = new SqlConnection(sb.ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(SP_SelectProduct, con);
                cmd.CommandType =CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                con.Close();

                model = new ProductModel();
                List<ProductEntity> l_lstProduct = new List<ProductEntity>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    ProductEntity item = new ProductEntity();
                    item.ProductId = Convert.ToInt32(dr["ProductId"]);
                    item.ProductCode = Convert.ToString(dr["ProductCode"]);
                    item.ProductName = Convert.ToString(dr["ProductName"]);
                    item.ProductPrice = Convert.ToDecimal(dr["ProductPrice"]);
                    l_lstProduct.Add(item);
                }

                model.lstProduct = l_lstProduct;
                return model;

            }catch(Exception ex)
            { 
                model = new ProductModel();
                model.Msg = new _MessageModel(ExceptionCode,ex.Message,MessageError);
                return model;
            }
        }

        public ProductModel EditProduct(ProductModel reqModel)
        {
            ProductModel model = null;
            try
            {
                SqlConnection con = new SqlConnection(sb.ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(SP_EditProductByProductId, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ProductId", reqModel.ProductId);
                cmd.Parameters.AddWithValue("ProductCode", reqModel.ProductCode);
                cmd.Parameters.AddWithValue("ProductName",reqModel.ProductName);
                cmd.Parameters.AddWithValue("ProductPrice",reqModel.ProductPrice);
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                DataRow dr = dt.Rows[0];
                con.Close();

                model = new ProductModel();
                model.Msg = new _MessageModel(dr["RespCode"].ToString(), dr["RespDesp"].ToString(), dr["RespType"].ToString());

                return model;
               
            }catch(Exception ex)
            {
                model = new ProductModel();
                model.Msg = new _MessageModel(ExceptionCode, ex.Message, MessageError);
                return model;
            }
        }

        public ProductModel DeleteProduct(string id)
        {
            ProductModel model = null;
            try
            {
                SqlConnection con = new SqlConnection(sb.ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(SP_DeleteProduct, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ProductId", id);
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                con.Close();

                DataRow dr = dt.Rows[0];
                model = new ProductModel();
                model.Msg = new _MessageModel(dr["RespCode"].ToString(), dr["RespDesp"].ToString(), dr["RespType"].ToString());
                return model;

            }catch(Exception ex)
            {
                model = new ProductModel();
                model.Msg = new _MessageModel(ExceptionCode, ex.Message, MessageError);
                return model;
            }
        }

        public ProductModel InsertProduct(ProductModel reqProduct)
        {
            ProductModel model = new ProductModel();
            try
            {
                SqlConnection con = new SqlConnection(sb.ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(SP_InsertProduct, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ProductCode", reqProduct.ProductCode);
                cmd.Parameters.AddWithValue("ProductName", reqProduct.ProductName);
                cmd.Parameters.AddWithValue("ProductPrice", reqProduct.ProductPrice);
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                DataRow dr = dt.Rows[0];
                con.Close();

                model = new ProductModel();
                model.Msg = new _MessageModel(dr["RespCode"].ToString(), dr["RespDesp"].ToString(), dr["RespType"].ToString());

                return model;

            }
            catch (Exception ex)
            {
                model = new ProductModel();
                model.Msg = new _MessageModel(ExceptionCode, ex.Message, MessageError);
                return model;
            }
        }
    }
} 