using System;
using System.Collections.Generic;

namespace prac17.models;

public partial class Участники
{
    public int Id { get; set; }

    public string Фамилия { get; set; } = null!;

    public string Имя { get; set; } = null!;

    public string Отчество { get; set; } = null!;

    public string Город { get; set; } = null!;

    public string ФамилияТренера { get; set; } = null!;

    public string Танец { get; set; } = null!;

    public int Оценка { get; set; }
}
