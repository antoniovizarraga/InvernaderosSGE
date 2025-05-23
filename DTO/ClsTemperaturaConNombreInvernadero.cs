﻿using ENT;

namespace DTO
{
    public class ClsTemperaturaConNombreInvernadero : ClsTemperatura
    {
        public string Nombre { get; }

        public ClsTemperaturaConNombreInvernadero(int IdInvernadero, DateTime Fecha) : base(IdInvernadero, Fecha.Date)
        {
            //TODO: ¿Quizás usar método de la BL para que por defecto en el constructor le asigne el nombre que tenga en la BBDD?
        }

        public ClsTemperaturaConNombreInvernadero(string Nombre, int IdInvernadero, DateTime Fecha) : base(IdInvernadero, Fecha.Date)
        {
            this.Nombre = Nombre;
        }

        public ClsTemperaturaConNombreInvernadero(string Nombre, int IdInvernadero, DateTime Fecha, Double? temp1, Double? temp2, Double? temp3, Double? humedad1, Double? humedad2, Double? humedad3) : base(IdInvernadero, Fecha.Date, temp1, temp2, temp3, humedad1, humedad2, humedad3)
        {
            this.Nombre = Nombre;
        }
    }
}
