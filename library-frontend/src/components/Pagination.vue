<template>
    <div class="pagination-container flex items-center justify-between">
        <div class="pagination-info">
            Showing <b>{{ startRange }}</b> to <b>{{ endRange }}</b> of <b>{{ totalItems }}</b> entries
        </div>

        <div class="pagination-controls flex">
            <button @click="changePage(currentPage - 1)"
                    :disabled="currentPage === 1"
                    class="page-btn">
                &laquo;
            </button>

            <button v-for="page in totalPages"
                    :key="page"
                    @click="changePage(page)"
                    :class="['page-btn', { active: currentPage === page }]">
                {{ page }}
            </button>

            <button @click="changePage(currentPage + 1)"
                    :disabled="currentPage === totalPages"
                    class="page-btn">
                &raquo;
            </button>
        </div>
    </div>
</template>

<script setup>
    import { computed } from 'vue';
    import '../assets/css/Utilities.css'

const props = defineProps({
  totalItems: { type: Number, default: 0 },
  itemsPerPage: { type: Number, default: 10 },
  currentPage: { type: Number, default: 1 }
});

const emit = defineEmits(['update:currentPage']);

const totalPages = computed(() => Math.ceil(props.totalItems / props.itemsPerPage));
const startRange = computed(() => (props.currentPage - 1) * props.itemsPerPage + 1);
const endRange = computed(() => Math.min(props.currentPage * props.itemsPerPage, props.totalItems));

const changePage = (page) => {
  if (page >= 1 && page <= totalPages.value) {
    emit('update:currentPage', page);
  }
};
</script>

<style scoped>
    .pagination-container {
        padding: 1rem 1.5rem;
        background: #fff;
        border-top: 1px solid #eef2f6; /* Matches your table border */
        border-bottom-left-radius: 8px;
        border-bottom-right-radius: 8px;
        font-family: sans-serif;
        color: #64748b;
        font-size: 14px;
        margin-bottom:40px;
    }

    .pagination-controls {
        gap: 5px;
    }

    .page-btn {
        border: 1px solid #e2e8f0;
        background: white;
        color: #334155;
        padding: 6px 12px;
        border-radius: 6px;
        cursor: pointer;
        transition: all 0.2s ease;
        font-weight: 500;
    }

    .page-btn:hover:not(:disabled) {
        background-color: #f8fafc;
        border-color: #cbd5e1;
    }

    .page-btn.active {
        background-color: #2563eb; /* Matches your "Dashboard" blue */
        color: white;
        border-color: #2563eb;
    }

    .page-btn:disabled {
        opacity: 0.5;
        cursor: not-allowed;
    }

    b {
        color: #1e293b;
    }
</style>