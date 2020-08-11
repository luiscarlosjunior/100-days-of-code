# -*- coding: utf-8 -*-
"""
Created on Tue Aug 11 11:33:44 2020

@author: luisc
"""

# -*- coding: utf-8 -*-
"""
Created on Tue Aug 11 11:22:32 2020

@author: luisc
"""
import numpy as np
import matplotlib.pyplot as plt

#ignore the warning of zero division
# or np.seterr(divide="ignore", invalid="ignore")
np.seterr(divide="ignore") 

#initial solution you'd like to start at
x = 2
y = 1

#the himmelblau function
#objective function value
z = ((x**2) + y - 11)**2 + (x + (y**2)-7)**2

print()
print("initial x is: %0.3f" % x)
print("initial y is: %0.3f" % y)
print("initial z is: %0.3f" % z)

#hyperparameter (user inputted parameters)
#the temperature (temp.)
T0 = 1000 
temp_for_plot = T0

M = 300 # how many times you will decrease the temp.
N = 15 #how many times you want to search your neighborhood
alpha = 0.85 # by how much do you want to decrease the temp
            # when you increase m by 1 (m small)

k = 0.1 #helps reduce the step-size, for example, if your random number
        # was 0.9 and your x value was 1, to make your step size in
        # the search space smaller, instead of making your new x value
        # 1.9 (1 + .9), you can multiply the random number (.9) with a small
        # number to ensure you will take a smaller step.. so, if k = 0.1, then
        # 0.9 * .1 = .09, wich will make your new x value 1.09 (1 + .09).. this
        # helps you search the search space more efficiently by being more
        # through insted of jumping around and taking a large step that may
        # lead you to pass the optimal or near-optimal solution
        
temp = [] #to plot the temperature
obj_val = [] #to plot the obj val reached at the end of each (m small M)



