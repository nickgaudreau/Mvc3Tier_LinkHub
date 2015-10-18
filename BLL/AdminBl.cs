using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using BOL;

namespace BLL
{
    public class AdminBl : BaseBl
    {
        public void ApproveOrReject(List<int> ids, string status)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    foreach (var id in ids)
                    {
                        var url = urlBl.GetById(id);
                        url.c_IsApproved = status;
                        urlBl.Update(url);
                    }

                    // if does not reach line below iot will rollback any ops/trans
                    transactionScope.Complete();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }
    }
}
