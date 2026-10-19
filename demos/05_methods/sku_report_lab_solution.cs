using System;

class SkuReport
{
   static string NormalizeSku(string raw)
   {
      return raw.Trim().ToUpper();
   }

   static string SkuCategory(string sku)
   {
      return sku.Substring(0, sku.IndexOf('-'));
   }

   static string SkuNumber(string sku)
   {
      return sku.Substring(sku.IndexOf('-') + 1, 4);
   }

   static string ReportLine(string raw)
   {
      string sku = NormalizeSku(raw);
      return string.Format("{0}: category {1}, item {2}", sku, SkuCategory(sku), SkuNumber(sku));
   }

   static void Main()
   {
      Console.WriteLine(ReportLine("  elec-1042-blk "));
      Console.WriteLine(ReportLine("OFFC-2210-WHT"));
      Console.WriteLine(ReportLine(" furn-0307-oak"));
   }
}
