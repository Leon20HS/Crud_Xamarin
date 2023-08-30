using app2_xamarin.model;
using app2_xamarin.Servicio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace app2_xamarin.ViewModel
{
    public class PersonaViewModel:PersonaModel
    {
        public ObservableCollection<PersonaModel> Personas { get; set; }
        PersonaServicio servicio = new PersonaServicio();
        PersonaModel modelo;

        public PersonaViewModel()
        {
            Personas = servicio.Consultar();
            GuardarCommand = new Command(async () => await Guardar(), () => !Isbusy);
            ModificarCommand = new Command(async () => await Modificar(),()=> !Isbusy);
            EliminarCommand = new Command(async () => await Eliminar(),()=> !Isbusy);
            LimpiarCommand = new Command(Limpiar,()=> !Isbusy);
        }

        public Command GuardarCommand { get; set; }
        public Command ModificarCommand { get; set; }

        public Command EliminarCommand { get; set; }

        public Command LimpiarCommand { get; set; }

        private async Task Guardar() {
            Isbusy = true;
            Guid IdPersona=Guid.NewGuid();
            modelo = new PersonaModel() {
                Nombre = Nombre,
                Apellido = Apellido,
                Edad = Edad,
                Id = IdPersona.ToString()
            };

            servicio.Guardar(modelo);
            await Task.Delay(2000);
            Isbusy = false;
        }

        private async Task Modificar() {

            Isbusy = true;
            
            modelo = new PersonaModel()
            {
                Nombre = Nombre,
                Apellido = Apellido,
                Edad = Edad,
                Id = Id
            };

            servicio.Modificar(modelo);
            await Task.Delay(2000);
            Isbusy = false;
        }

        private async Task Eliminar() {

            Isbusy = true;
            
            servicio.Eliminar(Id);
            await Task.Delay(2000);
            Isbusy = false;
        }


        private void Limpiar() {
            Nombre = "";
            Apellido = "";
            Edad = 0;
            Id = "";
        
        }


    }
}
