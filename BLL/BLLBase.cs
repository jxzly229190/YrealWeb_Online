using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Common;
using DAL;
using IModel;

namespace BLL
{
    public class BLLBase
    {
        private DAL.DALBase dal;

        public BLLBase()
        {
            dal=new DALBase();
        }

        public int Add(Common.DataContext ctx, IModel.BaseTable baseTable)
        {
            int rel = 0;
            rel = dal.Add(ctx, baseTable);

            return rel;
        }

        public int Update(Common.DataContext ctx, IModel.BaseTable baseTable)
        {
            int rel = 0;
            rel = dal.Update(ctx, baseTable);

            return rel;
        }

        public DataSet GetDataSet(DataContext ctx, BaseProcedure baseProcedure)
        {
            return dal.GetDataSet(ctx, baseProcedure);
        }

        public DataTable Select(Common.DataContext ctx, IModel.BaseTable baseTable)
        {
            return dal.Select(ctx, baseTable);
        }
    }
}
