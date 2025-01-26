using System;
using System.Data.SqlClient;
using System.Windows.Forms;

public class Conexion
{
    private SqlConnection connection;
    private readonly string connectionString = @"Server=DESKTOP-2I6K8G4\SQLEXPRESS;Database=BDOneCode;Trusted_Connection=True;";
    

    public SqlConnection OpenConnection()
    {
        try
        {
            if (connection == null)             
                connection = new SqlConnection(connectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();

            return connection;
        }
        catch (SqlException ex)
        {
            MessageBox.Show($"Error al abrir la conexión: {ex.Message}", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            throw; // Lanza la excepción para manejarla en niveles superiores
        }
    }

    public void CloseConnection()
    {
        try
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                connection = null; // Establece la conexión a null para permitir una nueva conexión
            }
        }
        catch (SqlException ex)
        {
            MessageBox.Show($"Error al cerrar la conexión: {ex.Message}", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            throw; // Lanza la excepción para manejarla en niveles superiores
        }
    }
}