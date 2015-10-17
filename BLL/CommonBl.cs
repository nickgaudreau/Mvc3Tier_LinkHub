using System;
using System.Transactions;
using BOL;

namespace BLL
{
    public class CommonBl : BaseBl
    {
        public void InsertQuickSubmit(QuickSubmit quickSubmit)
        {

            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    tbl_User user = quickSubmit.User;
                    user.c_Password = user.c_ConfirmPassword = new Random().Next(0, 100000).ToString("D6");
                    user.c_Role = User.RoleAuthorizedUser.Value;
                    userBl.Insert(user);

                    tbl_Url url = quickSubmit.Url;
                    url.i_UserId = user.i_UserId; // since inserted above it willl have an id generated for us by EF
                    url.c_UrlDesc = url.c_UrlTitle;
                    url.c_IsApproved = Url.StatusPending.Value;
                    urlBl.Insert(url);

                    // if does not rezch line below iot will rollback any ops/trans
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
