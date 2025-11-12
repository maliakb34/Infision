using System;
using System.Collections.Generic;

namespace EF;

public partial class Product
{
    public int Id { get; set; }

    public int? PriceAutoCalculateId { get; set; }

    public int? BrandId { get; set; }

    public string? StockChannelBrandName { get; set; }

    public int ExternalErpTypeId { get; set; }

    public int CompanyId { get; set; }

    public string? ProductSellerCode { get; set; }

    public int? Quantity { get; set; }

    public string? Title { get; set; }

    public string? Subtitle { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public decimal DisplayPrice { get; set; }

    public bool? IsDomestic { get; set; }

    public int? CurrencyType { get; set; }

    public int? ApprovalStatus { get; set; }

    public DateTime? SaleStartDate { get; set; }

    public DateTime? SaleEndDate { get; set; }

    public DateTime? ProductionDate { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public int? ProductCondition { get; set; }

    public int? PreparingDay { get; set; }

    public int? TaxRate { get; set; }

    public int? CategoryId { get; set; }

    public string? BrandName { get; set; }

    public string? Oemcode { get; set; }

    public int? PaketMiktari { get; set; }

    public bool? IsBuyerPayTheShipping { get; set; }

    public string? ProductStatusName { get; set; }

    public string? VendorCategoryId { get; set; }

    public string? CategoryName { get; set; }

    public string? ImageUrl { get; set; }

    public DateTime UpdateDate { get; set; }
}
