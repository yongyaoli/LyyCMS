
//using System;
//using System.Collections.Generic;
//using Abp.Application.Services;
//using L._52ABP.Application.Dtos;
//using L._52ABP.Common.Extensions.Enums;

//using LyyCMS.DataExporting.Excel.Epplus;
//using LyyCMS.DataFileObjects.DataTempCache;
//using LyyCMS.Members.Dtos;


//namespace LyyCMS.Members.Exporting
//{
//    /// <summary>
//    /// 验证码的视图模型根据业务需要可以导出为Excel文件
//    /// </summary>
//	[RemoteService(IsEnabled = false)]
//    public class VerificationCodeListExcelExporter : EpplusExcelExporterBase, IVerificationCodeListExcelExporter
//    {       
//        /// <summary>
//        /// 构造函数，需要继承父类
//        /// </summary>
//        /// <param name="dataTempFileCacheManager"></param>
//        public VerificationCodeListExcelExporter(IDataTempFileCacheManager dataTempFileCacheManager):base(dataTempFileCacheManager)
//        {

//        }
//        public FileDto ExportToExcelFile(List<VerificationCodeListDto> verificationCodeListDtos)
//        {

//    var fileExportName = L("VerificationCodeList") + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

//            var excel =
//                 CreateExcelPackage(fileExportName, excelpackage =>
//               {
//                   var sheet = excelpackage.Workbook.Worksheets.Add(L("VerificationCodes"));

//                   sheet.OutLineApplyStyle = true;
//			AddHeader(sheet,L("VerificationCodemember"),L("SendTime"),L("ExpireTime"),L("VerificationCodeCode"),L("Count"));
//            AddObject(sheet, 2, verificationCodeListDtos
//             ,ex => ex.member 
//             ,ex => ex.SendTime 
//             ,ex => ex.ExpireTime 
//             ,ex => ex.Code 
//             ,ex => ex.Count 
//                   );
//            sheet.Column(2).Style.Numberformat.Format = "yyyy-mm-dd";              
//            sheet.Column(3).Style.Numberformat.Format = "yyyy-mm-dd";              

//							//// custom codes
									
							

//							//// custom codes end
//	  });
//    return excel;
//        }
//    }
//}
