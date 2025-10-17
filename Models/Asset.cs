using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WealthWebApi.Models;

public class Asset
{
    public string? AssetDescription { get; set; }

    [Key]
    public required string AssetId { get; set; }

    public required string AssetInfo { get; set; }

    public required string AssetInfoType { get; set; }

    public string? AssetMask { get; set; }

    public string? AssetName { get; set; }

    public string? AssetOwnerName { get; set; }

    public DateTimeOffset BalanceAsOf { get; set; }

    public decimal? BalanceCostBasis { get; set; }

    public required string BalanceCostFrom { get; set; }

    public decimal? BalanceCurrent { get; set; }

    public required string BalanceFrom { get; set; }

    public decimal? BalancePrice { get; set; }

    public required string BalancePriceFrom { get; set; }


    public decimal? BalanceQuantityCurrent { get; set; }


    public string? BeneficiaryComposition { get; set; }


    public Guid? CognitoId { get; set; }


    public DateTime? CreationDate { get; set; }


    public string? CurrencyCode { get; set; }


    public string? DeactivateBy { get; set; }


    public required string DescriptionEstatePlan { get; set; }


    public string? HasInvestment { get; set; }


    public Holdings? Holdings { get; set; }


    public bool? IncludeInNetWorth { get; set; }


    public int? InstitutionId { get; set; }


    public string? InstitutionName { get; set; }


    public string? Integration { get; set; }


    public string? IntegrationAccountId { get; set; }


    public bool? IsActive { get; set; }


    public bool? IsAsset { get; set; }


    public bool? IsFavorite { get; set; }


    public string? IsLinkedVendor { get; set; }


    public DateTimeOffset? LastUpdate { get; set; }


    public DateTime? LastUpdateAttempt { get; set; }


    public string? LogoName { get; set; }


    public DateTime? ModificationDate { get; set; }


    public string? NextUpdate { get; set; }


    public required string Nickname { get; set; }


    public string? Note { get; set; }


    public string? NoteDate { get; set; }


    public string? Ownership { get; set; }


    public required string PrimaryAssetCategory { get; set; }


    public string? Status { get; set; }


    public string? StatusCode { get; set; }


    public required string UserInstitutionId { get; set; }


    public string? VendorAccountType { get; set; }


    public string? VendorContainer { get; set; }


    public string? VendorResponse { get; set; }


    public required string VendorResponseType { get; set; }


    public required string WealthAssetType { get; set; }


    public Guid? Wid { get; set; }

}


public class Holdings
{
    [JsonIgnore]
    public Guid Id {  get; set; } = new Guid();
    public ICollection<MajorAssetClasse> MajorAssetClasses { get; set; } = null!;

}


public class MajorAssetClasse
{
    [JsonIgnore]
    public Guid Id { get; set; } = new Guid();

    public ICollection<AssetClasse> AssetClasses { get; set; } = null!;


    public required string MajorClass { get; set; }

}

public class AssetClasse
{
    [JsonIgnore]
    public Guid Id { get; set; } = new Guid();

    public required string MinorAssetClass { get; set; }


    public decimal? Value { get; set; }

}
