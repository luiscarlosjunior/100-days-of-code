# -*- coding: utf-8 -*-
"""
Created on Fri Apr 24 11:01:00 2020
@author: luisc
"""
import pandas as pd

idade = pd.Series([10, 10, 12, 15, 16, 18, 150])

idade.plot()

print(idade.describe())