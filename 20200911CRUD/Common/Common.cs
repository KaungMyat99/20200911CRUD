using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _20200911CRUD.Common
{
    public static class CommonMethod
    {
        public const string MessageError = "ME";
        public const string MessageSuccess = "MS";
        public const string MessageWarning = "MW";
        public const string MessageInfo = "MI";
        public const string SuccessCode = "000";
        public const string ExceptionCode = "999";
    }
}

namespace _20200911CRUD
{
    public static class ProcedureConstant
    {
        public const string SP_SelectProduct = "SP_SelectProduct";
        public const string SP_EditProductByProductId = "SP_EditProductByProductId";
        public const string SP_DeleteProduct = "SP_DeleteProduct";
        public const string SP_InsertProduct = "SP_InsertProduct";
    }
}