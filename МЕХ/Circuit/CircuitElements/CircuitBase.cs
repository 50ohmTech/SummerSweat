﻿using System;
using System.Collections.Generic;
using System.Numerics;

namespace CircuitElements
{
	public abstract class CircuitBase : ICircuitElement
	{
		#region Static fields

		/// <summary>
		///     Уникальный идентификатор.
		/// </summary>
		private static int _uniqueId;

		#endregion

		#region Private fields

		/// <summary>
		///     Список элементов цепи
		/// </summary>
		private List<ICircuitElement> _elements;

		#endregion

		#region Properties

		/// <summary>
		///     Список элементов электрической цепи
		/// </summary>
		public List<ICircuitElement> Elements
		{
			get => _elements;
			set
			{
				_elements = value ?? throw new NullReferenceException(
					            "An attempt to assign a null value to the " +
					            nameof(Elements));

				foreach (var element in _elements)
				{
					element.ElementChanged += ChangedElementInvoke;
				}
			}
		}

		/// <summary>
		///     ID элемента
		/// </summary>
		public int Id { get; }

		#endregion

		#region Events

		/// <summary>
		///     Событие, которое загорается при изменении элемента
		/// </summary>
		public event ElementStateHandler ElementChanged;

		#endregion

		#region Constructor

		/// <summary>
		///     Конструктор без цепи
		/// </summary>
		public CircuitBase()
		{
			Elements = new List<ICircuitElement>();
			Id = _uniqueId;
			_uniqueId++;
		}

		/// <summary>
		///     Конструктор c цепью
		/// </summary>
		/// <param name="elements"> Список элементов электрической цепи </param>
		public CircuitBase(List<ICircuitElement> elements)
		{
			Elements = elements;
			Id = _uniqueId;
			_uniqueId++;
		}

		#endregion

		#region Private methods

		/// <summary>
		/// </summary>
		/// <param name="newValue"></param>
		/// <param name="valueOwner"></param>
		private void ChangedElementInvoke(object newValue, ElementBase valueOwner)
		{
			ElementChanged?.Invoke(newValue, valueOwner);
		}

		#endregion

		#region Public methods

		/// <summary>
		///     Получить количество элементов в длинну
		/// </summary>
		/// <returns>количество элементов в длинну</returns>
		public abstract int GetCircuitLength();

		/// <summary>
		///     Получить количество элементов в ширину
		/// </summary>
		/// <returns>количество элементов в длинну</returns>
		public abstract int GetCircuitWidth();

		/// <summary>
		///     Получить подцепь по ее ID
		/// </summary>
		/// <param name="id"></param>
		/// <returns>цепь</returns>
		public CircuitBase GetCircuitById(int id)
		{
			if (Id == id)
			{
				return this;
			}

			foreach (var element in Elements)
			{
				if (element is CircuitBase circuit)
				{
					if (circuit.Id == id)
					{
						return circuit;
					}

					return GetCircuitById(id, circuit);
				}
			}

			return null;
		}

		/// <summary>
		///     Получить подцепь по ее ID
		/// </summary>
		/// <param name="id"></param>
		/// <returns>цепь</returns>
		public CircuitBase GetCircuitById(int id, CircuitBase childCircuit)
		{
			foreach (var element in childCircuit.Elements)
			{
				if (element is CircuitBase circuit)
				{
					if (circuit.Id == id)
					{
						return circuit;
					}

					return GetCircuitById(id, circuit);
				}
			}

			return null;
		}

		/// <summary>
		///     Расчитать импаденс по входной частоте
		/// </summary>
		/// <param name="frequence">Частоты сигнала</param>
		/// <returns></returns>
		public abstract Complex CalculateZ(double frequence);

		#endregion
	}
}