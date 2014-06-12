using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Common;
using IModel;

namespace DAL
{
    public class DALBase
    {
        public int Add(DataContext ctx, BaseTable baseTable)
        {
            Common.DataAccess da = new Common.DataAccess();
            if (ctx != null)
                da.ctx = ctx;
            da.TableEntity = baseTable;
            return da.Insert();
        }

        public int Update(DataContext ctx, BaseTable baseTable)
        {
            Common.DataAccess da = new Common.DataAccess();
            if (ctx != null)
                da.ctx = ctx;
            da.TableEntity = baseTable;
            return da.Update();
        }

        public DataSet GetDataSet(DataContext ctx, BaseProcedure baseProcedure)
        {
            Common.DataAccess da = new Common.DataAccess();
            if (ctx != null)
                da.ctx = ctx;
            da.ProcedureEntity = baseProcedure;
            return da.ExecuteDataSet();
        }

        public DataTable Select(DataContext ctx, BaseTable baseTable)
        {
            Common.DataAccess da = new Common.DataAccess();
            if (ctx != null)
                da.ctx = ctx;
            da.TableEntity = baseTable;
            return da.Select();
        }
    }
}
