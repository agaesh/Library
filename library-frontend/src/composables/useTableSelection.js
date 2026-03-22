import { ref, computed, watch } from "vue";

export function useTableSelection(rowsRef, emit) {

    const selectedRows = ref([]);

    // ✅ derived state
    const selectAll = computed(() => {
        return rowsRef.value.length > 0 &&
            selectedRows.value.length === rowsRef.value.length;
    });

    function toggleSelectAll(e) {
        const isChecked = e.target.checked;

        if (isChecked) {
            selectedRows.value = rowsRef.value.map(r => r.id);
        } else {
            selectedRows.value = [];
        }

        emit("checkbox-selection", selectedRows.value);
    }
     
    // ❌ no need toggleRow if using v-model (Vue handles it)

    // Optional: reset selection when data changes

    watch(selectedRows, (val) => {
        // Whenever selection changes, notify parent
        emit("checkbox-selection", val);
    });

    return {
        selectedRows,
        selectAll,
        toggleSelectAll
    };
}