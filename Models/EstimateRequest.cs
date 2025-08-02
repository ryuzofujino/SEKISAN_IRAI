using System;
using System.ComponentModel.DataAnnotations;

namespace SEKISAN_IRAI.Models;

public class EstimateRequest
{
    [Key]
    [Display(Name = "No")]
    public int Id { get; set; }

    [Display(Name = "依頼日")]
    [DataType(DataType.Date)]
    public DateTime? RequestDate { get; set; }

    [Display(Name = "積算希望日")]
    [DataType(DataType.Date)]
    public DateTime? DesiredEstimateDate { get; set; }

    [Required]
    [Display(Name = "案件名")]
    public string ProjectName { get; set; } = string.Empty;

    [Display(Name = "請負区分")]
    public string? ContractType { get; set; }

    [Display(Name = "ZAC案件番号")]
    public string? ZacProjectNumber { get; set; }

    [Display(Name = "営業担当")]
    public string? SalesPerson { get; set; }

    [Display(Name = "積算担当")]
    public string? Estimator { get; set; }

    [Display(Name = "ステータス")]
    public string? Status { get; set; }

    [Display(Name = "積算完了日")]
    [DataType(DataType.Date)]
    public DateTime? EstimateCompletionDate { get; set; }

    [Display(Name = "備考")]
    public string? Remarks { get; set; }

    [Display(Name = "積算資料BOXURL")]
    [Url]
    public string? DocumentsUrl { get; set; }

    [Display(Name = "その他メモ")]
    public string? Notes { get; set; }
}