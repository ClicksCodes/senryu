export const numSort = (arr: number[], sortFn?: (a: number, b: number) => number): number[] => {
	return arr.sort(sortFn ? sortFn : (a, b) => a>b ? 1 : -1);
}

