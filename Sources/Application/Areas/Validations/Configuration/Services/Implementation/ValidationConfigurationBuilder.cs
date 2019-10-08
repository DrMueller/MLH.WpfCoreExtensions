﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Validation.Models;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Configuration.Services.Implementation
{
    internal class ValidationConfigurationBuilder<T> : IValidationConfigurationBuilder<T>
        where T : ValidatableViewModel<T>
    {
        private readonly List<PropertyRulesBuilder<T>> _rulesBuilders;
        private readonly ValidatableViewModel<T> _viewModel;

        internal ValidationConfigurationBuilder(ValidatableViewModel<T> viewModel)
        {
            _rulesBuilders = new List<PropertyRulesBuilder<T>>();
            _viewModel = viewModel;
        }

        public ValidationContainer<T> Build()
        {
            var propertyValidations = _rulesBuilders.Select(f => f.BuildValidation()).ToList();
            var container = new ValidationContainer<T>(_viewModel, propertyValidations);
            return container;
        }

        public IPropertyRulesBuilder<T> ForProperty<TField>(Expression<Func<T, TField>> expression)
        {
            if (!(expression.Body is MemberExpression propertyExpression))
            {
                throw new ArgumentException("You must pass a lambda of the form: '() => Class.Property' or '() => object.Property'");
            }

            var propName = propertyExpression.Member.Name;
            var rulesBuilder = new PropertyRulesBuilder<T>(propName, this);
            _rulesBuilders.Add(rulesBuilder);
            return rulesBuilder;
        }
    }
}