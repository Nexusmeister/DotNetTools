﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;

namespace Tools.Core.Models.Administration
{
    public class Customizing
    {
        public int Id { get; set; }
        /// <summary>
        /// Beschreibung des Customizing-Eintrags
        /// </summary>
        public string Beschreibung { get; set; }
        /// <summary>
        /// Anlagezeitpunkt des Eintrags
        /// </summary>
        public DateTime Anlagedatum { get; set; }
        /// <summary>
        /// Zeitpunkt der letzten Änderung
        /// </summary>
        public DateTime? Aenderungsdatum { get; set; }
        /// <summary>
        /// String Customizing
        /// </summary>
        public string StringWert { get; set; }
        /// <summary>
        /// Integer Customizing
        /// </summary>
        public int? IntWert { get; set; }
    }
}