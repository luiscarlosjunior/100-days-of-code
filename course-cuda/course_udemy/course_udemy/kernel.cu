
#include "cuda_runtime.h"
#include "device_launch_parameters.h"

#include <stdio.h>

cudaError_t addWithCuda(int *c, const int *a, const int *b, unsigned int size);

void printThreadIds();

__global__ void addKernel(int *c, const int *a, const int *b)
{
    int i = threadIdx.x;
    c[i] = a[i] + b[i];
}

__global__ void hello_cuda()
{
	printf("Hello Cuda world \n");
}

__global__ void print_threadIds()
{
	printf("threadIdx.x: %d, threadIdx.y: %d, threadIdx.z: %d\n",
		threadIdx.x, threadIdx.y, threadIdx.z);
}

// Print blocks and grid
__global__ void print_threadIds()
{
	printf("blockIdx.x: %d, blockIdx.y: %d, blockIdx.z: %d blockDim.x: %d, blockDim.y: %d\n",
		threadIdx.x, threadIdx.y, threadIdx.z);
}

int main()
{
	// HelloWorld();

	printThreadIds();

	return 0;
}

void printThreadIds() {
	int nx, ny;
	nx = 16;
	ny = 16;

	dim3 block(8, 8);
	dim3 grid(nx / block.x, ny / block.y);

	print_threadIds << < grid, block >> > ();
	cudaDeviceSynchronize();

	cudaDeviceReset();

}

void HelloWorld() {
	// Executa CUDA World

	int nx, ny;
	nx = 16;
	ny = 4;


	dim3 block(8, 2);
	dim3 grid(nx / block.x, 2);

	hello_cuda << < grid, block >> > ();
	cudaDeviceSynchronize();
	
}
