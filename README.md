# NetSentinel 🛡️

**NetSentinel** es una herramienta de auditoría de red desarrollada en C# diseñada para monitorear la latencia y disponibilidad de nodos críticos en tiempo real.

A diferencia de un simple ping por consola, este proyecto aplica lógica defensiva orientada a **DevSecOps** e **Infraestructura**: interactúa directamente con el sistema operativo para generar evidencia automática (Logs) ante cualquier interrupción del servicio.

## 🚀 Características Principales

* **Auditoría ICMP Activa:** Utiliza la clase `System.Net.NetworkInformation.Ping` para enviar paquetes reales y medir el *RoundtripTime* hacia cualquier IP o dominio.
* **Generación Automática de Logs:** Si un host deja de responder o la conexión falla, el sistema crea/actualiza un archivo `Log_Alertas.txt` en el Escritorio del usuario dejando un registro exacto del evento para futuras auditorías de seguridad.
* **Lógica Defensiva (Try-Catch):** Implementa manejo de excepciones de `System.IO` para evitar cierres abruptos (crashes) si el sistema operativo o el antivirus bloquean la escritura del archivo de registro.

## 🛠️ Tecnologías Utilizadas
* **Lenguaje:** C# (.NET 8.0)
* **Librerías Core:** * `System.Net.NetworkInformation` (Interacción con hardware de red)
  * `System.IO` (Manejo de archivos y persistencia de datos)
