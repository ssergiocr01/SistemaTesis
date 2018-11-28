
class Formularios {
    constructor(fechaLlenado, asentamiento, tenenciaIndicadores, familiaIndicadores, educacionPrimariaIndicadores, educacionSecundariaIndicadores,
        saludIndicadores, cuidoIndicadores, imasIndicadores, recreativoIndicadores, conPersoneria, sinPersoneria, accesoAgua, accesoElectricidad,
        aguasResiduales, recoleccionBasura, hurtos, violenciaIntrafamiliar, abandono, alcoholismo, empleo, edadProductiva, empleoInformal, empleoInfantil,
        jefesHogar, embarazosAdoslescentes, miembrosCostarricenses, miembroExtranjero, residenciaPermanente, condicionIrregular, nombreEvaluador, institucion,
        numCedula, observaciones, valorFinal) {
        this.fechaLlenado = fechaLlenado;
        this.asentamiento = asentamiento;
        this.tenenciaIndicadores = tenenciaIndicadores;
        this.familiaIndicadores = familiaIndicadores;
        this.educacionPrimariaIndicadores = educacionPrimariaIndicadores;
        this.educacionSecundariaIndicadores = educacionSecundariaIndicadores;
        this.saludIndicadores = saludIndicadores;
        this.cuidoIndicadores = cuidoIndicadores;
        this.imasIndicadores = imasIndicadores;
        this.recreativoIndicadores = recreativoIndicadores;
        this.conPersoneria = conPersoneria;
        this.sinPersoneria = sinPersoneria;
        this.accesoAgua = accesoAgua;
        this.accesoElectricidad = accesoElectricidad;
        this.aguasResiduales = aguasResiduales;
        this.recoleccionBasura = recoleccionBasura;
        this.hurtos = hurtos;
        this.violenciaIntrafamiliar = violenciaIntrafamiliar;
        this.abandono = abandono;
        this.alcoholismo = alcoholismo;
        this.empleo = empleo;
        this.edadProductiva = edadProductiva;
        this.empleoInformal = empleoInformal;
        this.empleoInfantil = empleoInfantil;
        this.jefesHogar = jefesHogar;
        this.embarazosAdoslescentes = embarazosAdoslescentes;
        this.miembrosCostarricenses = miembrosCostarricenses;
        this.miembroExtranjero = miembroExtranjero;
        this.residenciaPermanente = residenciaPermanente;
        this.condicionIrregular = condicionIrregular;
        this.nombreEvaluador = nombreEvaluador;
        this.institucion = institucion;
        this.numCedula = numCedula;
        this.observaciones = observaciones;
        this.valorFinal = valorFinal;
    }

    getFormularioAsentamiento(id, funcion) {
        var action = this.action;
        var count = 1;
        $.ajax({
            type: "POST",
            url: action,
            data: {},
            success: (response) => {
                //console.log(response);
                document.getElementById('AsentamientoFormulario').options[0] = new Option("[Seleccione un asentamiento]", 0);

                if (0 < response.length) {
                    for (var i = 0; i < response.length; i++) {
                        if (0 == funcion) {
                            document.getElementById('AsentamientoFormulario').options[count] = new Option(response[i].nombre, response[i].asentamientoID);
                            count++;
                        } else {
                            if (id == response[i].asentamientoID) {
                                document.getElementById('AsentamientoFormulario').options[0] = new Option(response[i].nombre, response[i].asentamientoID);
                                document.getElementById('AsentamientoFormulario').selectedIndex = 0;
                                break;
                            }
                        }
                    }
                }
            }
        });
    }
}
