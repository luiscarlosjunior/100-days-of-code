
#include "cuda_runtime.h"
#include "device_launch_parameters.h"

#include <stdio.h>

__global__ void unique_idx_calc_threadIdx(int * input)
{
	int tid = threadIdx.x;
	printf("threadIdx: %d, value: %d \n", tid, input[tid]);
}

int main()
{
	int array_size = 8;
	int array_byte_size = sizeof(int) * array_size;
	int h_data[] = { 23, 9, 4, 53, 65, 12, 1, 33 };

	for (size_t i = 0; i < array_size; i++)
	{
		printf("%d ", h_data[i]);
	}
	printf("\n \n");
	
	int * d_data;
	cudaMalloc((void**) &d_data, array_byte_size);
	cudaMemcpy(d_data, h_data, array_byte_size, cudaMemcpyHostToDevice);

	dim3 block(4);
	dim3 grid(1);

	unique_idx_calc_threadIdx << < grid, block >> > (d_data);
	cudaDeviceSynchronize();

	cudaDeviceReset();
    return 0;
}
