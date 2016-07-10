using System;
using System.IO;
using System.Threading.Tasks;
using DineroPortableClientSDK;
using think.dinero_up.ShellExtension.Exceptions;

namespace think.dinero_up.ShellExtension.Clients
{
    public class DineroClient
    {
        private readonly Dinero _dinero = new Dinero(ClientConfiguration.ClientId, ClientConfiguration.ClientSecret, ClientConfiguration.ApiKey, ClientConfiguration.CompanyId);

        public void UploadVoucher(FileInfo file)
        {
            _dinero.FilesAddImage(file.FullName, result =>
            {
                if (result.HasError)
                    throw new DineroUploadException(result.ErrorMessage);

                _dinero.PurchaseVouchersAddVoucher(
                    new PurchaseVoucherCreate {FileGuid = result.Result.FileGuid, Notes = file.Name, VoucherDate = DateTime.Now.ToString("yyyy-MM-dd")},
                    r =>
                    {
                        if (r.HasError)
                            throw new DineroUploadException(r.ErrorMessage);
                    });
            });
             
        }
    }
}