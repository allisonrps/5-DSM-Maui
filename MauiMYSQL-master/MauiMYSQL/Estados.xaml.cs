using Microsoft.Maui.Dispatching;
using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using MauiMYSQL.Models;

namespace MauiMYSQL
{
    public partial class PageEstados : ContentPage
    {
        private ObservableCollection<Estado> listaEstados = new ObservableCollection<Estado>();
        private bool isProcessing = false;

        public PageEstados()
        {
            InitializeComponent();
            BindingContext = this;
            lstEstados.ItemsSource = listaEstados;
            CarregarEstados();
        }

        private async void CarregarEstados()
        {
            if (isProcessing) return;
            isProcessing = true;

            UpdateStatus("Carregando estados...", Colors.Blue);

            try
            {
                var estados = new Estados();
                bool resultado = await Task.Run(() => estados.Estados_Consulta());

                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    if (resultado)
                    {
                        listaEstados.Clear();
                        foreach (var estado in estados.listaEstados)
                        {
                            listaEstados.Add(estado);
                        }
                        UpdateStatus($"{listaEstados.Count} estados carregados", Colors.Green);
                    }
                    else
                    {
                        UpdateStatus("Banco de Dados OFF", Colors.Red);
                        DisplayAlert("Erro", "Falha ao carregar estados", "OK");
                    }
                });
            }
            catch (Exception ex)
            {
                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    UpdateStatus("Erro de conexão", Colors.Red);
                    DisplayAlert("Erro", $"Erro ao consultar estados: {ex.Message}", "OK");
                });
            }
            finally
            {
                isProcessing = false;
            }
        }

        private async void btnAdicionar(object sender, EventArgs e)
        {
            if (isProcessing) return;
            isProcessing = true;

            string nome = txtNome.Text?.Trim();
            string sigla = txtSigla.Text?.Trim().ToUpper();
            string bandeira = txtBandeira.Text?.Trim();

            // Validation
            if (string.IsNullOrWhiteSpace(nome))
            {
                await DisplayAlert("Aviso", "Informe o nome do estado", "OK");
                txtNome.Focus();
                isProcessing = false;
                return;
            }

            if (string.IsNullOrWhiteSpace(sigla) || sigla.Length != 2)
            {
                await DisplayAlert("Aviso", "A sigla deve ter 2 caracteres", "OK");
                txtSigla.Focus();
                isProcessing = false;
                return;
            }

            if (string.IsNullOrWhiteSpace(bandeira))
            {
                await DisplayAlert("Aviso", "Informe uma URL para a bandeira", "OK");
                txtBandeira.Focus();
                isProcessing = false;
                return;
            }

            UpdateStatus("Adicionando estado...", Colors.Blue);

            try
            {
                var estados = new Estados();
                bool sucesso = await Task.Run(() => estados.Estados_Add(nome, sigla, bandeira));

                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    if (sucesso)
                    {
                        // Add new item directly instead of reloading everything
                        listaEstados.Add(new Estado { nome = nome, sigla = sigla, bandeira_url = bandeira });

                        txtNome.Text = string.Empty;
                        txtSigla.Text = string.Empty;
                        txtBandeira.Text = string.Empty;
                        UpdateStatus("Estado adicionado!", Colors.Green);
                        txtNome.Focus();
                    }
                    else
                    {
                        UpdateStatus("Banco de Dados OFF", Colors.Red);
                        DisplayAlert("Erro", $"Falha ao adicionar: {estados.conexao_status}", "OK");
                    }
                });
            }
            catch (Exception ex)
            {
                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    UpdateStatus("Erro crítico", Colors.Red);
                    DisplayAlert("Erro", ex.Message, "OK");
                });
            }
            finally
            {
                isProcessing = false;
            }
        }

        private void UpdateStatus(string message, Color color)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                lblStatus.Text = message;
                lblStatus.TextColor = color;
            });
        }
    }
}