using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Printing;

namespace Capa_de_Servicios_SL_
{
    public class _824_ecGestorPdf
    {
        private PrintDocument documento_824_ec;
        private string contenido_824_ec;
        private Font fuente_824_ec;
        private int posicion_824_ec;

        public _824_ecGestorPdf()
        {
            documento_824_ec = new PrintDocument();

            documento_824_ec.DefaultPageSettings.Margins = new Margins(50, 50, 50, 50);

            documento_824_ec.PrintPage += Documento_PrintPage;

            documento_824_ec.Disposed += (sender, e) =>
            {
                fuente_824_ec?.Dispose();
                fuente_824_ec = null;
            };
        }

        private void Documento_PrintPage(object sender, PrintPageEventArgs e)
        {
            float margenSuperior = e.MarginBounds.Top;
            float margenIzquierdo = e.MarginBounds.Left;

            float alturaLinea = fuente_824_ec.GetHeight(e.Graphics);
            float posicionY = margenSuperior;

            float anchoDisponible = e.MarginBounds.Width;

            string textoNormalizado = contenido_824_ec
                .Replace("\r\n", "\n")
                .Replace("\r", "\n");

            string[] lineas = textoNormalizado.Split('\n');

            while (posicion_824_ec < lineas.Length)
            {
                string linea = lineas[posicion_824_ec];

                // Dividir la línea si supera el ancho disponible.
                List<string> fragmentos = DividirLinea_824_ec( linea, e.Graphics, anchoDisponible);

                foreach (string fragmento in fragmentos)
                {
                    if (posicionY + alturaLinea > e.MarginBounds.Bottom)
                    {
                        e.HasMorePages = true;
                        return;
                    }

                    e.Graphics.DrawString( fragmento, fuente_824_ec, Brushes.Black,
                        margenIzquierdo, posicionY);

                    posicionY += alturaLinea;
                }

                posicion_824_ec++;
            }

            e.HasMorePages = false;
            posicion_824_ec = 0;
        }

        public void ConfigurarReporte_824_ec(string contenido)
        {
            if (string.IsNullOrWhiteSpace(contenido))
                throw new ArgumentException(
                    "El contenido del reporte no puede estar vacío.");

            fuente_824_ec?.Dispose();

            contenido_824_ec = contenido;
            fuente_824_ec = new Font("Arial", 11);
            posicion_824_ec = 0;
        }

        public PrintDocument ObtenerDocumento_824_ec()
        {
            if (string.IsNullOrWhiteSpace(contenido_824_ec))
                throw new InvalidOperationException(
                    "Primero debe configurarse el contenido del reporte.");

            posicion_824_ec = 0;

            return documento_824_ec;
        }

        private List<string> DividirLinea_824_ec( string linea, Graphics graphics, float anchoDisponible)
        {
            List<string> fragmentos = new List<string>();

            if (string.IsNullOrEmpty(linea))
            {
                fragmentos.Add("");
                return fragmentos;
            }

            string[] palabras = linea.Split(' ');
            string fragmentoActual = "";

            foreach (string palabra in palabras)
            {
                string posibleFragmento = string.IsNullOrEmpty(fragmentoActual)? palabra: fragmentoActual + " " + palabra;

                SizeF medida = graphics.MeasureString( posibleFragmento, fuente_824_ec);

                if (medida.Width <= anchoDisponible)
                {
                    fragmentoActual = posibleFragmento;
                }
                else
                {
                    if (!string.IsNullOrEmpty(fragmentoActual))
                        fragmentos.Add(fragmentoActual);

                    fragmentoActual = palabra;
                }
            }

            if (!string.IsNullOrEmpty(fragmentoActual))
                fragmentos.Add(fragmentoActual);

            return fragmentos;
        }
    }
}
