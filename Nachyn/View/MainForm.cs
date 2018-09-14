using System.Collections.Generic;
using System.Windows.Forms;
using Model.Elements.Enums;
using Model.ViewHelpers;
using Model.ViewHelpers.Enums;

namespace View
{
    public partial class MainForm : Form
    {
        #region Private methods

        /// <summary>
        ///     Инициализировать ComboBox'ы
        /// </summary>
        private void InitializeComboBoxesType()
        {
            List<ElementTypeComboBoxItem> elementTypes = new List<ElementTypeComboBoxItem>
            {
                new ElementTypeComboBoxItem(ElementType.Resistor),
                new ElementTypeComboBoxItem(ElementType.Inductor),
                new ElementTypeComboBoxItem(ElementType.Capacitor)
            };

            _comboBoxAddElementType.DataSource = elementTypes;
            _comboBoxAddElementType.ValueMember = "Value";
            _comboBoxAddElementType.DisplayMember = "Description";

            List<InitialCircuitTypeComboBoxItem> initialCircuitTypes = new List<InitialCircuitTypeComboBoxItem>
            {
                new InitialCircuitTypeComboBoxItem(InitialCircuitType.A),
                new InitialCircuitTypeComboBoxItem(InitialCircuitType.B),
                new InitialCircuitTypeComboBoxItem(InitialCircuitType.C),
                new InitialCircuitTypeComboBoxItem(InitialCircuitType.D),
                new InitialCircuitTypeComboBoxItem(InitialCircuitType.E)
            };

            _comboBoxSelectCircuit.DataSource = initialCircuitTypes;
            _comboBoxSelectCircuit.ValueMember = "Value";
            _comboBoxSelectCircuit.DisplayMember = "Description";

            List<ConnectionTypeComboBoxItem> connectionTypes = new List<ConnectionTypeComboBoxItem>
            {
                new ConnectionTypeComboBoxItem(ConnectionType.Serial),
                new ConnectionTypeComboBoxItem(ConnectionType.Parallel)
            };

            _comboBoxAddElementConnectionType.DataSource = connectionTypes;
            _comboBoxAddElementConnectionType.ValueMember = "Value";
            _comboBoxAddElementConnectionType.DisplayMember = "Description";
        }

        #endregion

        #region Public methods

        public MainForm()
        {
            InitializeComponent();
            InitializeComboBoxesType();
        }

        #endregion
    }
}