﻿namespace Job.Notes.Domain.Entities;

public class QuestionEntity: BaseEntity
{
    public string Question { get; set; }
    public string Answer { get; set; }
    public string AdditionalNote { get; set; }
    public int QuestionListId { get; set; }
    public QuestionListEntity QuestionList { get; set; }
}