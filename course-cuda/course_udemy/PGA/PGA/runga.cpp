// C++ program to create target string, starting from 
// random string using Genetic Algorithm 

#include <string>
#include <vector>
#include <time.h>
#include <stdio.h>
#include <iostream>
#include <algorithm>
#include "cuda_runtime.h"
#include "device_launch_parameters.h"
#include "kernel.cuh"

using namespace std;

// Number of individuals in each generation 
#define POPULATION_SIZE 100 

// Valid Genes 
const string GENES = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOP"\
"QRSTUVWXYZ 1234567890, .-;:_!\"#%&/()=?@${[]}";

// Target string to be generated 
const string TARGET = "I love GeeksforGeeks";


// Function to generate random numbers in given range 
int random_num(int start, int end)
{
	int range = (end - start) + 1;
	int random_int = start + (rand() % range);
	return random_int;
}

// Create random genes for mutation 
char mutated_genes()
{
	int len = GENES.size();
	int r = random_num(0, len - 1);
	return GENES[r];
}

// create chromosome or string of genes 
string create_gnome()
{
	int len = TARGET.size();
	string gnome = "";
	for (int i = 0; i<len; i++)
		gnome += mutated_genes();
	return gnome;
}

// Class representing individual in population 
class Individual
{
public:
	string chromosome;
	int fitness;
	Individual(string chromosome);
	Individual mate(Individual parent2);
	int cal_fitness();
};

Individual::Individual(string chromosome)
{
	this->chromosome = chromosome;
	fitness = cal_fitness();
};

// Perform mating and produce new offspring 
Individual Individual::mate(Individual par2)
{
	// chromosome for offspring 
	string child_chromosome = "";

	int len = chromosome.size();
	for (int i = 0; i<len; i++)
	{
		// random probability 
		float p = random_num(0, 100) / 100;

		// if prob is less than 0.45, insert gene 
		// from parent 1 
		if (p < 0.45)
			child_chromosome += chromosome[i];

		// if prob is between 0.45 and 0.90, insert 
		// gene from parent 2 
		else if (p < 0.90)
			child_chromosome += par2.chromosome[i];

		// otherwise insert random gene(mutate), 
		// for maintaining diversity 
		else
			child_chromosome += mutated_genes();
	}

	// create new Individual(offspring) using 
	// generated chromosome for offspring 
	return Individual(child_chromosome);
};

// Calculate fitness score, it is the number of 
// characters in string which differ from target 
// string. 
int Individual::cal_fitness()
{
	int len = TARGET.size();
	int fitness = 0;
	for (int i = 0; i<len; i++)
	{
		if (chromosome[i] != TARGET[i])
			fitness++;
	}
	return fitness;
};

// Overloading < operator 
bool operator<(const Individual &ind1, const Individual &ind2)
{
	return ind1.fitness < ind2.fitness;
}

// Driver code 
int main()
{
	std::cout << "Entrando no arquivo" << std::endl;
	// Initialize arrays A, B, and C.
	double A[3], B[3], C[3];

	// Populate arrays A and B.
	A[0] = 5; A[1] = 8; A[2] = 3;
	B[0] = 7; B[1] = 6; B[2] = 4;

	// Sum array elements across ( C[0] = A[0] + B[0] ) into array C using CUDA.
	kernel(A, B, C, 3);

	// Print out result.
	std::cout << "C = " << C[0] << ", " << C[1] << ", " << C[2] << std::endl;

	system("pause");

	srand((unsigned)(time(0)));

	// current generation 
	int generation = 0;

	vector<Individual> population;
	bool found = false;

	// create initial population 
	for (int i = 0; i<POPULATION_SIZE; i++)
	{
		string gnome = create_gnome();
		population.push_back(Individual(gnome));
	}

	while (!found)
	{
		// sort the population in increasing order of fitness score 
		sort(population.begin(), population.end());

		// if the individual having lowest fitness score 
		// 0 then we know that we have reached to the target 
		// and break the loop 
		if (population[0].fitness <= 0)
		{
			found = true;
			break;
		}

		// Otherwise generate new offspring for new generation 
		vector<Individual> new_generation;

		// Perform Elitism, that mean 10% of fittest population 
		// goes to the next generation 
		int s = (10 * POPULATION_SIZE) / 100;
		for (int i = 0; i<s; i++)
			new_generation.push_back(population[i]);

		// From 50% of fittest population, Individuals 
		// will mate to produce offspring 
		s = (90 * POPULATION_SIZE) / 100;
		for (int i = 0; i<s; i++)
		{
			int len = population.size();
			int r = random_num(0, 50);
			Individual parent1 = population[r];
			r = random_num(0, 50);
			Individual parent2 = population[r];
			Individual offspring = parent1.mate(parent2);
			new_generation.push_back(offspring);
		}
		population = new_generation;
		cout << "Generation: " << generation << "\t";
		cout << "String: " << population[0].chromosome << "\t";
		cout << "Fitness: " << population[0].fitness << "\n";

		generation++;
	}
	cout << "Generation: " << generation << "\t";
	cout << "String: " << population[0].chromosome << "\t";
	cout << "Fitness: " << population[0].fitness << "\n";
	
	system("pause");
}
